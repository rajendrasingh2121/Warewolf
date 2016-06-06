﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.Studio.UISpecs.Tools
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DecisionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Control Flow - Decision.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Decision", "In order to branch based on the data\r\nAs Warewolf user\r\nI want tool that be makes" +
                    " a true or false (yes/no) decision based on the data", ProgrammingLanguage.CSharp, ((string[])(null)));
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
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Decision")))
            {
                Warewolf.Studio.UISpecs.Tools.DecisionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Decision Large View")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Decision")]
        public virtual void OpeningDecisionLargeView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Decision Large View", new string[] {
                        "Decision",
                        "ignore"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I have Decision tool on the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I double click on \"Decision\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("\"statement1 of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("\"statement1 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("\"TextBox1\" is focussed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table1.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "NO"});
#line 16
 testRunner.And("Evaluates a statement to True or False", ((string)(null)), table1, "And ");
#line 19
 testRunner.And("Diplay text as \"If Choose..\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("True arm text as \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("False arm text as \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("Require All decision to be True selected as \"Yes\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("Done button is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding Statements in Decision Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void AddingStatementsInDecisionTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding Statements in Decision Tool", new string[] {
                        "ignore"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I have Decision tool on the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("I double click on \"Decision\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("the large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("\"statement1 of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("\"statement1 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("\"TextBox1\" is focussed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table2.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "NO"});
#line 33
 testRunner.And("Evaluates a statement to True or False", ((string)(null)), table2, "And ");
#line 36
 testRunner.When("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table3.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table3.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
#line 37
 testRunner.Then("Statements are", ((string)(null)), table3, "Then ");
#line 41
 testRunner.And("Diplay text as \"If Choose..\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("True arm text as \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("False arm text as \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("Require All decision to be True selected as \"Yes\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("Done button is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding Statements more then five appears scroll bar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void AddingStatementsMoreThenFiveAppearsScrollBar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding Statements more then five appears scroll bar", new string[] {
                        "ignore"});
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("Decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.When("I click on \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table4.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
#line 56
 testRunner.Then("Evaluates a statement to True or False", ((string)(null)), table4, "Then ");
#line 64
 testRunner.Then("scroll bar is \"visible\" on \"Decion large view\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("Diplay text as \"If Choose..\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("True arm text as \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("False arm text as \"False\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("Require All decision to be True selected as \"Yes\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("Done button is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting Statements in Decision Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void DeletingStatementsInDecisionTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting Statements in Decision Tool", new string[] {
                        "ignore"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("Decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table5.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
            table5.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "Yes"});
#line 74
 testRunner.Then("Statements are", ((string)(null)), table5, "Then ");
#line 78
 testRunner.When("I delete \"statement1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table6.AddRow(new string[] {
                        "\"\"",
                        "Choose...",
                        "",
                        "NO"});
#line 79
 testRunner.Then("Evaluates a statement to True or False", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting Statement in combobox1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void SelectingStatementInCombobox1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Selecting Statement in combobox1", new string[] {
                        "ignore"});
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("Decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.And("\"statement1 of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("\"statement1 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.When("I select \"statement1\" of combobox as \"There Is An Error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.Then("\"statement1\" of \"TextBox1\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
 testRunner.And("\"statement1\" of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I select \"statement2\" of combobox as \"There Is No Error\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("\"statement2\" of \"TextBox1\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.And("\"statement2\" of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.When("I select \"statement3\" of combobox as \"=\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("\"statement3\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.And("\"statement3\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.When("I select \"statement4\" of combobox as \">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
 testRunner.Then("\"statement4\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
 testRunner.And("\"statement4\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.When("I select \"statement5\" of combobox as \"<\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
 testRunner.Then("\"statement5\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.And("\"statement5\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table7.AddRow(new string[] {
                        "",
                        "There Is An Error",
                        "",
                        "Yes"});
            table7.AddRow(new string[] {
                        "",
                        "There Is No Error",
                        "",
                        "Yes"});
            table7.AddRow(new string[] {
                        "\"\"",
                        "=",
                        "\"\"",
                        "Yes"});
            table7.AddRow(new string[] {
                        "\"\"",
                        ">",
                        "\"\"",
                        "Yes"});
            table7.AddRow(new string[] {
                        "\"\"",
                        "<",
                        "\"\"",
                        "Yes"});
#line 112
 testRunner.Then("Evaluates a statement to True or False", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting Statement in combobox2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void SelectingStatementInCombobox2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Selecting Statement in combobox2", new string[] {
                        "ignore"});
#line 123
this.ScenarioSetup(scenarioInfo);
#line 124
 testRunner.Given("Decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 125
 testRunner.And("\"statement1 of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("\"statement1 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.When("I select \"statement1\" of combobox as \"<> (Not Equal)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
 testRunner.Then("\"statement1\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.And("\"statement1\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.When("I select \"statement2\" of combobox as \">=\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
 testRunner.Then("\"statement2\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.And("\"statement2\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.When("I select \"statement3\" of combobox as \"<=\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
 testRunner.Then("\"statement3\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
 testRunner.And("\"statement3 of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.When("I select \"statement4\" of combobox as \"Starts With\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
 testRunner.Then("\"statement4\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
 testRunner.And("\"statement4 of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.When("I select \"statement5\" of combobox as \"Ends With\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
 testRunner.Then("\"statement5\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 150
 testRunner.And("\"statement5\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.When("I select \"statement6\" of combobox as \"Contains\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then("\"statement6\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
 testRunner.And("\"statement6\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table8.AddRow(new string[] {
                        "\"\"",
                        "<> (Not Equal)",
                        "\"\"",
                        "Yes"});
            table8.AddRow(new string[] {
                        "\"\"",
                        ">=",
                        "\"\"",
                        "Yes"});
            table8.AddRow(new string[] {
                        "\"\"",
                        "<=",
                        "\"\"",
                        "Yes"});
            table8.AddRow(new string[] {
                        "\"\"",
                        "Starts With",
                        "\"\"",
                        "Yes"});
            table8.AddRow(new string[] {
                        "\"\"",
                        "Ends With",
                        "\"\"",
                        "Yes"});
            table8.AddRow(new string[] {
                        "\"\"",
                        "Contains",
                        "\"\"",
                        "Yes"});
#line 156
 testRunner.Then("Evaluates a statement to True or False", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selecting Statement in combobox3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void SelectingStatementInCombobox3()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Selecting Statement in combobox3", new string[] {
                        "ignore"});
#line 169
this.ScenarioSetup(scenarioInfo);
#line 170
 testRunner.Given("Decision large view is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
 testRunner.And("\"statement1\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.And("\"statement1\" of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.When("I select \"statement1\" of combobox as \"Doesn\'t Start With\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
 testRunner.Then("\"statement1\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
 testRunner.And("\"statement1\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.When("I select \"statement2\" of combobox as \"Doesn\'t Contain\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 180
 testRunner.Then("\"statement2\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 181
 testRunner.And("\"statement2\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 183
 testRunner.When("I select \"statement3\" of combobox as \"Is Alphanumeric\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 184
 testRunner.Then("\"statement3\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 185
 testRunner.And("\"statement3\" of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.When("I select \"statement4\" of combobox as \"Is Base64\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 189
 testRunner.Then("\"statement4\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 190
 testRunner.And("\"statement4\" of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.When("I select \"statement5\" of combobox as \"Is Between\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 194
 testRunner.Then("\"statement5\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 195
 testRunner.And("\"statement5\" of \"TextBox2\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
 testRunner.And("\"statement5\" of \"TextBox3\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
 testRunner.When("I select \"statement6\" of combobox as \"Is Binary\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
 testRunner.Then("\"statement6\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
 testRunner.And("\"statement6 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.And("I \"Add Statement\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
 testRunner.When("I select \"statement7\" of combobox as \"Is Date\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
 testRunner.Then("\"statement7\" of \"TextBox1\" is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 206
 testRunner.And("\"statement7 of \"TextBox2\" is \"NotVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "TextBox1",
                        "ComboBox",
                        "TextBox2",
                        "Delete"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Doesn\'t Start With",
                        "\"\"",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Doesn\'t Contain",
                        "\"\"",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Is Alphanumeric",
                        "",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Is Base64",
                        "",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Is Between",
                        "\"\"",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Is Binary",
                        "",
                        "Yes"});
            table9.AddRow(new string[] {
                        "\"\"",
                        "Is Date",
                        "",
                        "Yes"});
#line 207
 testRunner.Then("Evaluates a statement to True or False", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
