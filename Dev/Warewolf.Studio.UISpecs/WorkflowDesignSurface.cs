﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace Warewolf.Studio.UISpecs
{
    /// <summary>
    /// Summary description for WorkflowDesignSurface
    /// </summary>
    [CodedUITest]
    public class WorkflowDesignSurface
    {
        public WorkflowDesignSurface()
        {
        }

        [TestMethod]
        public void BigWorkflowDesignSurfaceUITest()
        {
            Uimap.Assert_NewWorkFlow_RibbonButton_Exists();
            Uimap.Click_New_Workflow_Ribbon_Button();
            Uimap.Assert_StartNode_Exists();
            Uimap.Assert_Toolbox_Multiassign_Exists();

            //Given that the unit before this one passed its post asserts
            //UIMap.Assert_StartNode_Exists();
            //Uimap.Assert_Toolbox_Multiassign_Exists();
            Uimap.Drag_Toolbox_MultiAssign_Onto_DesignSurface();
            Uimap.Assert_Assign_Small_View_Row1_Variable_Textbox_Exists();

            //Action Unit: Double Clicking Multi Assign Tool Small View on the Design Surface Opens Large View
            //UIMap.Assert_MultiAssign_Exists_OnDesignSurface();
            //Uimap.Assert_Assign_Small_View_Row1_Variable_Textbox_Text_is_SomeVariable();
            Uimap.Open_Assign_Tool_Large_View();
            Uimap.Assert_Assign_Large_View_Exists_OnDesignSurface();
            Uimap.Assert_Assign_Large_View_Row1_Variable_Textbox_Exists();

            //Action Unit: Enter Text into Multi Assign Tool Small View Grid Column 1 Row 1 Textbox has text in text property
            //UIMap.Assert_Assign_Large_View_Exists_OnDesignSurface();
            //Uimap.Assert_Assign_Large_View_Row1_Variable_Textbox_Exists();
            Uimap.Enter_Text_Into_Assign_Large_View_Row1_Variable_Textbox_As_SomeVariable();
            Uimap.Assert_Assign_Large_View_Row1_Variable_Textbox_Text_Equals_SomeVariable();

            //Action Unit: Validating Multi Assign Tool with a variable entered into the Large View on the Design Surface Passes Validation and Variable is in the Variable list
            //UIMap.Assert_Assign_Large_View_Exists_OnDesignSurface();
            //Uimap.Assert_Assign_Large_View_Row1_Variable_Textbox_Text_Equals_SomeVariable();
            Uimap.Click_Assign_Tool_Large_View_DoneButton();
            Uimap.Assert_Assign_Small_View_Row1_Variable_Textbox_Text_is_SomeVariable();
            Uimap.Assert_VariableList_Scalar_Row1_Textbox_Equals_SomeVariable();

            //Action Unit: Click Assign Tool QVI Button Opens Qvi
            //UIMap.Assert_MultiAssign_Exists_OnDesignSurface();
            Uimap.Open_Assign_Tool_Qvi_Large_View();
            Uimap.Assert_Assign_QVI_Large_View_Exists_OnDesignSurface();

            //Action Unit: Clicking the save ribbon button opens save dialog
            Uimap.Assert_Save_Ribbon_Button_Exists();
            Uimap.Click_Save_Ribbon_Button();
            Uimap.Assert_SaveDialog_Exists();
            Uimap.Assert_SaveDialog_ServiceName_Textbox_Exists();

            //Action Unit: Entering a valid workflow name into the save dialog does not set the error state of the textbox to true
            //UIMap.Assert_Save_Workflow_Dialog_Exists();
            //Uimap.Assert_Workflow_Name_Textbox_Exists();
            Uimap.Enter_Servicename_As_SomeWorkflow();
            Uimap.Assert_SaveDialog_SaveButton_Enabled();

            //Action Unit: Clicking the save button in the save dialog dismisses save dialog
            //UIMap.Assert_SaveDialog_SaveButton_Enabled();
            Uimap.Click_SaveDialog_YesButton();
            Playback.Wait(1000);
            Uimap.Assert_MessageBox_Does_Not_Exist();

            //Action Unit: Filtering the explorer tree shows only SomeWorkflow on local server
            Uimap.Enter_SomeWorkflow_Into_Explorer_Filter();
            explorerTreeItemActionSteps.AssertExistsInExplorerTree("localhost\\SomeWorkflow");

            /**TODO: Re-introduce these units after bug is fixed
            //Action Unit: Clicking Debug Button Shows Debug Input Dialog
            //UIMap.Assert_MultiAssign_Exists_OnDesignSurface();
            //Uimap.Assert_Assign_Small_View_Row1_Variable_Textbox_Text_is_SomeVariable();
            Uimap.Click_Debug_Ribbon_Button();
            Uimap.Assert_DebugInput_Window_Exists();
            Uimap.Assert_DebugInput_DebugButton_Exists();

            //Action Unit: Clicking Debug Button In Debug Input Dialog Generates Debug Output
            //UIMap.Assert_Debug_Input_Dialog_Exists();
            //Uimap.Assert_DebugInput_DebugButton_Exists();
            Uimap.Click_DebugInput_DebugButton();
            Uimap.Assert_DebugOutput_Exists();
            Uimap.Assert_DebugOutput_SettingsButton_Exists();
            Uimap.Assert_DebugOutput_Contains_SomeVariable();
            **/
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.SearchTimeout = 10000;
            //ActionSteps.StartTest();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //Action Unit: Explorer context menu delete exists
            //Given "localhost\SomeWorkflow" exists in the explorer tree
            explorerTreeItemActionSteps.WhenIRightClickTheItemInTheExplorerTree("localhost\\SomeWorkflow");
            Uimap.Assert_ExplorerContextMenu_Delete_Exists();

            //Action Unit: Clicking delete in the explorer context menu on SomeWorkflow shows message box
            //UIMap.Assert_ExplorerConextMenu_Delete_Exists();
            Uimap.Select_Delete_FromExplorerContextMenu();
            Uimap.Assert_MessageBox_Yes_Button_Exists();

            //Action Unit: Clicking Yes on the delete prompt dialog dismisses the dialog
            //UIMap.Assert_MessageBox_Yes_Button_Exists();
            Uimap.Click_MessageBox_Yes();
            Uimap.Assert_MessageBox_Does_Not_Exist();

            //Action Unit: Clearing and refreshing the explorer filter removes SomeWorkflow from the explorer tree
            Uimap.Click_Explorer_Filter_Clear_Button();
            Uimap.Click_Explorer_Refresh_Button();
            explorerTreeItemActionSteps.AssertDoesNotExistInExplorerTree("localhost\\SomeWorkflow");
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        UIMap Uimap
        {
            get
            {
                if ((_uiMap == null))
                {
                    _uiMap = new UIMap();
                }

                return _uiMap;
            }
        }

        private UIMap _uiMap;

        Explorer_Tree_Item_Action_Steps explorerTreeItemActionSteps
        {
            get
            {
                if ((_explorerTreeItemActionSteps == null))
                {
                    _explorerTreeItemActionSteps = new Explorer_Tree_Item_Action_Steps();
                }

                return _explorerTreeItemActionSteps;
            }
        }

        private Explorer_Tree_Item_Action_Steps _explorerTreeItemActionSteps;
    }
}