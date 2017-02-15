﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.BrowserDebug
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class BrowserDebugFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BrowserDebug.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BrowserDebug", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "BrowserDebug")))
            {
                Dev2.Activities.Specs.BrowserDebug.BrowserDebugFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing an empty workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAnEmptyWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing an empty workflow", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given("I have a workflow \"BlankWorkflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
  testRunner.When("workflow \"BlankWorkflow\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.And("I Debug \"http://localhost:3142/secure/BlankWorkflow.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
  testRunner.Then("The Debug in Browser content contains \"The workflow must have at least one servic" +
                    "e or activity connected to the Start Node.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing a workflow with no inputs and outputs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAWorkflowWithNoInputsAndOutputs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing a workflow with no inputs and outputs", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
  testRunner.Given("I have a workflow \"NoInputsWorkflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
  testRunner.When("workflow \"NoInputsWorkflow\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
  testRunner.And("I Debug \"http://localhost:3142/secure/NoInputsWorkflow.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.Then("The Debug in Browser content contains has children with no Inputs and Ouputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Assign workflow with valid inputs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAssignWorkflowWithValidInputs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Assign workflow with valid inputs", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
  testRunner.Given("I have a workflow \"ValidAssignedVariableWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table1.AddRow(new string[] {
                        "dateMonth",
                        "February"});
            table1.AddRow(new string[] {
                        "dateYear",
                        "2017"});
#line 20
  testRunner.And("\"ValidAssignedVariableWF\" contains an Assign \"ValidAssignVariables\" as", ((string)(null)), table1, "And ");
#line 24
  testRunner.When("workflow \"ValidAssignedVariableWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
  testRunner.And("I Debug \"http://localhost:3142/secure/ValidAssignedVariableWF.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
  testRunner.Then("The Debug in Browser content contains has inputs and outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Assign workflow with invalid variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingAssignWorkflowWithInvalidVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Assign workflow with invalid variable", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
  testRunner.Given("I have a workflow \"InvalidAssignedVariableWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table2.AddRow(new string[] {
                        "d@teMonth",
                        "February"});
#line 30
  testRunner.And("\"InvalidAssignedVariableWF\" contains an Assign \"InvalidAssignVariables\" as", ((string)(null)), table2, "And ");
#line 33
  testRunner.When("workflow \"InvalidAssignedVariableWF\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
  testRunner.And("I Debug \"http://rsaklfdylan:3142/secure/Acceptance%20Tests/InvalidAssignedVariabl" +
                    "eWF.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
  testRunner.Then("The Debug in Browser content contains has error messagge \"\"invalid variable assig" +
                    "ned to d@teMonth\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Hello World workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BrowserDebug")]
        public virtual void ExecutingHelloWorldWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Hello World workflow", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
  testRunner.Given("I have a workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
  testRunner.When("\"Hello World\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
  testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
  testRunner.And("I Debug \"http://localhost:3142/secure/Hello World.debug?\" in Browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
  testRunner.And("The Debug in Browser content contains has inputs and outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
