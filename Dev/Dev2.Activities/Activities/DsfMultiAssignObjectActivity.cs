/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2;
using Dev2.Activities;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.Util;
using Dev2.Diagnostics;
using Dev2.MathOperations;
using Dev2.TO;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Dev2.Data.Interfaces.Enums;
using Dev2.Data.TO;
using Dev2.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Warewolf.Core;
using Warewolf.Resource.Errors;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;
using WarewolfParserInterop;

// ReSharper disable UnusedMember.Global

// ReSharper disable CheckNamespace
namespace Unlimited.Applications.BusinessDesignStudio.Activities
// ReSharper restore CheckNamespace
{
    [ToolDescriptorInfo("AssignObject", "Assign Object", ToolType.Native, "A86C4D10-B4D0-4775-AF4D-C66D5A6CE76F", "Dev2.Acitivities", "1.0.0.0", "Legacy", "Data", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_Data_Assign_Object")]
    public class DsfMultiAssignObjectActivity : DsfActivityAbstract<string>
    {
        public const string CalculateTextConvertPrefix = GlobalConstants.CalculateTextConvertPrefix;
        public const string CalculateTextConvertSuffix = GlobalConstants.CalculateTextConvertSuffix;
        public const string CalculateTextConvertFormat = GlobalConstants.CalculateTextConvertFormat;

        private IList<AssignObjectDTO> _fieldsCollection;

        // ReSharper disable ConvertToAutoProperty
        public IList<AssignObjectDTO> FieldsCollection
        // ReSharper restore ConvertToAutoProperty
        {
            get
            {
                return _fieldsCollection;
            }
            set
            {
                _fieldsCollection = value;
            }
        }

        public bool UpdateAllOccurrences { get; set; }
        public bool CreateBookmark { get; set; }
        public string ServiceHost { get; set; }

        [ExcludeFromCodeCoverage]
        protected override bool CanInduceIdle => true;

        public override List<string> GetOutputs()
        {
            return FieldsCollection.Select(dto => dto.FieldName).ToList();
        }

        public DsfMultiAssignObjectActivity()
            : base("Assign Object")
        {
            _fieldsCollection = new List<AssignObjectDTO>();
        }

        // ReSharper disable RedundantOverridenMember
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        // ReSharper restore RedundantOverridenMember
        [ExcludeFromCodeCoverage]
        protected override void OnExecute(NativeActivityContext context)
        {
            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            ExecuteTool(dataObject, 0);
        }

        protected override void ExecuteTool(IDSFDataObject dataObject, int update)
        {
            _debugOutputs.Clear();
            _debugInputs.Clear();

            InitializeDebug(dataObject);
            ErrorResultTO errors = new ErrorResultTO();
            ErrorResultTO allErrors = new ErrorResultTO();

            try
            {
                if (!errors.HasErrors())
                {
                    int innerCount = 1;
                    foreach (AssignObjectDTO t in FieldsCollection)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(t.FieldName))
                            {
                                UpdateField(dataObject, update, t, innerCount);
                            }
                            innerCount++;
                        }
                        catch (Exception e)
                        {
                            Dev2Logger.Error(e);
                            allErrors.AddError(e.Message);
                        }
                    }
                    dataObject.Environment.CommitAssign();
                    allErrors.MergeErrors(errors);
                }
            }
            catch (Exception e)
            {
                Dev2Logger.Error(e);
                allErrors.AddError(e.Message);
            }
            finally
            {
                // Handle Errors
                var hasErrors = allErrors.HasErrors();
                if (hasErrors)
                {
                    DisplayAndWriteError("DsfMultiAssignObjectActivity", allErrors);
                    var errorString = allErrors.MakeDisplayReady();
                    dataObject.Environment.AddError(errorString);
                }
                if (dataObject.IsDebugMode())
                {
                    DispatchDebugState(dataObject, StateType.Before, update);
                    DispatchDebugState(dataObject, StateType.After, update);
                }
            }
        }

        private void UpdateField(IDSFDataObject dataObject, int update, AssignObjectDTO t, int innerCount)
        {
            string fieldValue;
            string cleanExpression;
            var isCalcEvaluation = DataListUtil.IsCalcEvaluation(t.FieldValue, out cleanExpression);
            var doEvaluation = !isCalcEvaluation && DataListUtil.IsEvaluated(t.FieldValue);
            var warewolfEvalResult = dataObject.Environment.Eval(t.FieldValue, update);
            var valueResult = warewolfEvalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
            if (valueResult != null)//Willl Work for scalar Values
            {
                var atomToString = ExecutionEnvironment.WarewolfAtomToString(valueResult?.Item);
                fieldValue = atomToString;
                AssignJsonObject(dataObject, update, t, innerCount, fieldValue);

            }
            else if (warewolfEvalResult is CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult)// Handle Arrays
            {
                var warewolfListEvalResult = dataObject.Environment.EvalAsList(t.FieldValue, update);
                if (warewolfListEvalResult != null)
                    foreach (DataStorage.WarewolfAtom warewolfAtomResult in warewolfListEvalResult)
                    {
                        var valueResultFromList = warewolfAtomResult;
                        var atomToString = ExecutionEnvironment.WarewolfAtomToString(valueResultFromList);
                        fieldValue = atomToString;
                        AssignJsonObject(dataObject, update, t, innerCount, fieldValue);
                    }
            }

        }

        private void AssignJsonObject(IDSFDataObject dataObject, int update, AssignObjectDTO t, int innerCount,
            string fieldValue)
        {
            string cleanExpression;
            var isJson = fieldValue.IsJSON();
            if (isJson)
            {
                var jContainer = JsonConvert.DeserializeObject(fieldValue) as JContainer;
                try
                {
                    dataObject.Environment.Assign(t.FieldName, jContainer?.ToString(), update);
                }
                catch (Exception)
                {
                    // 
                }

                dataObject.Environment.AddToJsonObjects(t.FieldName, jContainer);
            }

            var assignValue = new AssignValue(t.FieldName, fieldValue);
            var isCalcEvaluation = DataListUtil.IsCalcEvaluation(t.FieldValue, out cleanExpression);
            if (isCalcEvaluation)
            {
                assignValue = new AssignValue(t.FieldName, cleanExpression);
            }
            DebugItem debugItem = null;
            if (dataObject.IsDebugMode())
            {
                debugItem = AddSingleInputDebugItem(dataObject.Environment, innerCount, assignValue, update);
            }
            if (isCalcEvaluation)
            {
                DoCalculation(dataObject.Environment, t.FieldName, fieldValue, update);
            }
            else if (!isJson)
            {
                dataObject.Environment.AssignJson(assignValue, update);
            }
            if (debugItem != null)
            {
                _debugInputs.Add(debugItem);
            }
            if (dataObject.IsDebugMode())
            {
                AddSingleDebugOutputItem(dataObject.Environment, innerCount, assignValue, update);
            }
        }

        private void DoCalculation(IExecutionEnvironment environment, string fieldName, string cleanExpression, int update)
        {
            var functionEvaluator = new FunctionEvaluator();
            var warewolfEvalResult = environment.Eval(cleanExpression, update);

            if (warewolfEvalResult.IsWarewolfAtomResult)
            {
                var result = warewolfEvalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                if (result != null)
                {
                    var eval = PerformCalcForAtom(result.Item, functionEvaluator);
                    var doCalculation = new AssignValue(fieldName, eval);
                    environment.AssignJson(doCalculation, update);
                }
            }
            if (warewolfEvalResult.IsWarewolfAtomListresult)
            {
                var result = warewolfEvalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                if (result != null)
                {
                    var counter = 1;
                    foreach (var item in result.Item)
                    {
                        var eval = PerformCalcForAtom(item, functionEvaluator);
                        var doCalculation = new AssignValue(fieldName, eval);
                        environment.AssignJson(doCalculation, update == 0 ? counter : update);
                        counter++;
                    }
                }
            }
        }

        private static string PerformCalcForAtom(DataStorage.WarewolfAtom warewolfAtom, FunctionEvaluator functionEvaluator)
        {
            var calcExpression = ExecutionEnvironment.WarewolfAtomToString(warewolfAtom);
            string exp;
            DataListUtil.IsCalcEvaluation(calcExpression, out exp);
            string eval;
            string error;
            var res = functionEvaluator.TryEvaluateFunction(exp, out eval, out error);
            if (eval == exp.Replace("\"", "") && exp.Contains("\""))
            {
                try
                {
                    string eval2;
                    var b = functionEvaluator.TryEvaluateFunction(exp.Replace("\"", ""), out eval2, out error);
                    if (b)
                    {
                        eval = eval2;
                    }
                }
                catch (Exception err)
                {
                    Dev2Logger.Warn(err);
                }
            }
            if (!res)
            {
                throw new Exception(ErrorResource.InvalidCalculate);
            }
            return eval;
        }

        private DebugItem AddSingleInputDebugItem(IExecutionEnvironment environment, int innerCount, IAssignValue assignValue, int update)
        {
            var debugItem = new DebugItem();
            const string VariableLabelText = "Variable";
            const string NewFieldLabelText = "New Value";

            try
            {
                if (!DataListUtil.IsEvaluated(assignValue.Value))
                {
                    if (assignValue.Name.EndsWith("()]]"))
                    {
                        throw new Exception("Append data to array");
                    }
                    CommonFunctions.WarewolfEvalResult evalResult = environment.Eval(assignValue.Name, update);
                    AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), debugItem);
                    if (evalResult.IsWarewolfAtomResult)
                    {
                        var scalarResult = evalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        if (scalarResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomResult(ExecutionEnvironment.WarewolfAtomToString(scalarResult.Item), assignValue.Value, environment.EvalToExpression(assignValue.Name, update), "", VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                    else if (evalResult.IsWarewolfAtomListresult)
                    {
                        AddDebugItem(new DebugItemWarewolfAtomListResult(null, assignValue.Value, "", environment.EvalToExpression(assignValue.Name, update), VariableLabelText, NewFieldLabelText, "="), debugItem);
                    }
                }
                else if (DataListUtil.IsEvaluated(assignValue.Value))
                {
                    if (assignValue.Name.EndsWith("()]]"))
                    {
                        throw new Exception("Append data to array");
                    }
                    var oldValueResult = environment.Eval(assignValue.Name, update);
                    var newValueResult = environment.Eval(assignValue.Value, update);
                    AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), debugItem);
                    if (oldValueResult.IsWarewolfAtomResult && newValueResult.IsWarewolfAtomResult)
                    {
                        var valueResult = newValueResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        var scalarResult = oldValueResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        if (valueResult != null && scalarResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomResult(ExecutionEnvironment.WarewolfAtomToString(scalarResult.Item), ExecutionEnvironment.WarewolfAtomToString(valueResult.Item), assignValue.Name, environment.EvalToExpression(assignValue.Value, update), VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                    else if ((newValueResult.IsWarewolfAtomResult && oldValueResult.IsWarewolfAtomListresult) || (oldValueResult.IsWarewolfAtomResult && newValueResult.IsWarewolfAtomListresult))
                    {
                        AddDebugItem(new DebugItemWarewolfAtomListResult(null, newValueResult, environment.EvalToExpression(assignValue.Value, update), assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                    }
                    else if (oldValueResult.IsWarewolfAtomListresult && newValueResult.IsWarewolfAtomListresult)
                    {
                        var old = (CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult)oldValueResult;
                        if (!old.Item.Any())
                        {
                            AddDebugItem(new DebugItemWarewolfAtomListResult(null, newValueResult, environment.EvalToExpression(assignValue.Value, update), assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                        else
                        {
                            var recSetResult = oldValueResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                            AddDebugItem(new DebugItemWarewolfAtomListResult(recSetResult, newValueResult, environment.EvalToExpression(assignValue.Value, update), assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("ParseError"))
                {
                    AddDebugItem(new DebugItemWarewolfAtomResult("", assignValue.Value, environment.EvalToExpression(assignValue.Name, update), "", VariableLabelText, NewFieldLabelText, "="), debugItem);
                    return debugItem;
                }
                string errorMessage;
                if (!ExecutionEnvironment.IsValidVariableExpression(assignValue.Name, out errorMessage, update))
                {
                    return null;
                }
                AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), debugItem);
                if (DataListUtil.IsEvaluated(assignValue.Value))
                {
                    var newValueResult = environment.Eval(assignValue.Value, update);

                    if (newValueResult.IsWarewolfAtomResult)
                    {
                        var valueResult = newValueResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        if (valueResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomResult("", ExecutionEnvironment.WarewolfAtomToString(valueResult.Item), environment.EvalToExpression(assignValue.Name, update), assignValue.Value, VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                    else if (newValueResult.IsWarewolfAtomListresult)
                    {
                        AddDebugItem(new DebugItemWarewolfAtomListResult(null, newValueResult, environment.EvalToExpression(assignValue.Value, update), assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                    }
                }
                else
                {
                    AddDebugItem(new DebugItemWarewolfAtomResult("", assignValue.Value, environment.EvalToExpression(assignValue.Name, update), "", VariableLabelText, NewFieldLabelText, "="), debugItem);
                }
            }
            return debugItem;
        }

        private void AddSingleDebugOutputItem(IExecutionEnvironment environment, int innerCount, IAssignValue assignValue, int update)
        {
            const string VariableLabelText = "";
            const string NewFieldLabelText = "";
            var debugItem = new DebugItem();

            try
            {
                if (!DataListUtil.IsEvaluated(assignValue.Value))
                {
                    var evalResult = environment.Eval(assignValue.Name, update);
                    AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), debugItem);
                    if (evalResult.IsWarewolfAtomResult)
                    {
                        var scalarResult = evalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        if (scalarResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomResult(ExecutionEnvironment.WarewolfAtomToString(scalarResult.Item), assignValue.Value, environment.EvalToExpression(assignValue.Name, update), "", VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                    else if (evalResult.IsWarewolfAtomListresult)
                    {
                        var recSetResult = evalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                        if (recSetResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomListResult(recSetResult, "", "", environment.EvalToExpression(assignValue.Name, update), VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                }
                else if (DataListUtil.IsEvaluated(assignValue.Value))
                {
                    var evalResult = environment.Eval(assignValue.Name, update);
                    AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), debugItem);
                    if (evalResult.IsWarewolfAtomResult)
                    {
                        var scalarResult = evalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomResult;
                        if (scalarResult != null)
                        {
                            AddDebugItem(new DebugItemWarewolfAtomResult(ExecutionEnvironment.WarewolfAtomToString(scalarResult.Item), "", environment.EvalToExpression(assignValue.Name, update), "", VariableLabelText, NewFieldLabelText, "="), debugItem);
                        }
                    }
                    var evalResult2 = environment.Eval(assignValue.Value, update);
                    if (evalResult.IsWarewolfAtomListresult)
                    {
                        var recSetResult = evalResult as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                        if (recSetResult != null)
                        {
                            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                            if (DataListUtil.GetRecordsetIndexType(assignValue.Name) == enRecordsetIndexType.Blank)
                            {
                                AddDebugItem(new DebugItemWarewolfAtomListResult(recSetResult, evalResult2, "", assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                            }
                            else
                            {
                                AddDebugItem(new DebugItemWarewolfAtomListResult(recSetResult, environment.EvalToExpression(assignValue.Value, update), "", assignValue.Name, VariableLabelText, NewFieldLabelText, "="), debugItem);
                            }
                        }
                    }
                }
            }
            catch (NullValueInVariableException)
            {
                AddDebugItem(new DebugItemWarewolfAtomResult("", assignValue.Value, "", environment.EvalToExpression(assignValue.Name, update), VariableLabelText, NewFieldLabelText, "="), debugItem);
            }
            _debugOutputs.Add(debugItem);
        }

        public override enFindMissingType GetFindMissingType()
        {
            return enFindMissingType.DataGridActivity;
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates)
        {
            foreach (Tuple<string, string> t in updates)
            {
                // locate all updates for this tuple
                Tuple<string, string> t1 = t;
                var items = FieldsCollection.Where(c => !string.IsNullOrEmpty(c.FieldValue) && c.FieldValue.Contains(t1.Item1));

                // issues updates
                foreach (var a in items)
                {
                    a.FieldValue = a.FieldValue.Replace(t.Item1, t.Item2);
                }
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates)
        {
            foreach (Tuple<string, string> t in updates)
            {
                // locate all updates for this tuple
                Tuple<string, string> t1 = t;
                var items = FieldsCollection.Where(c => !string.IsNullOrEmpty(c.FieldName) && c.FieldName.Contains(t1.Item1));

                // issues updates
                foreach (var a in items)
                {
                    a.FieldName = a.FieldName.Replace(t.Item1, t.Item2);
                }
            }
        }

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment dataList, int update)
        {
            return _debugInputs;
        }

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment dataList, int update)
        {
            return _debugOutputs;
        }

        public override IList<DsfForEachItem> GetForEachInputs()
        {
            return (from item in FieldsCollection
                    where !string.IsNullOrEmpty(item.FieldValue) && item.FieldValue.Contains("[[")
                    select new DsfForEachItem { Name = item.FieldName, Value = item.FieldValue }).ToList();
        }

        public override IList<DsfForEachItem> GetForEachOutputs()
        {
            return (from item in FieldsCollection
                    where !string.IsNullOrEmpty(item.FieldName) && item.FieldName.Contains("[[")
                    select new DsfForEachItem { Name = item.FieldValue, Value = item.FieldName }).ToList();
        }
    }
}