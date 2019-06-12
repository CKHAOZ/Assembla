using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Support
{
    public partial class EnrollmentForm : Form
    {
		// Constructor
        public EnrollmentForm(AppData data)
        {
            InitializeComponent();
			Data = data;										// Keep reference to the data
			ExchangeData(true);									// Init data with default control values;
			Data.OnChange += delegate { ExchangeData(false); };	// Track data changes to keep the form synchronized
        }

		// Simple dialog data exchange (DDX) implementation.
        public void ExchangeData(bool read)
        {
            if (read)
            {	// read values from the form's controls to the data object
                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
				Data.Update();
			}
            else
            {	// read values from the data object to the form's controls
                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }

        public void OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
			if (Data.IsEventHandlerSucceeds)
			{
				Data.Templates[Finger-1] = Template;		    // store a finger template
				ExchangeData(true);								// update other data
			}
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
		}

        public void OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds) {
                Data.Templates[Finger-1] = null;			    // clear the finger template
				ExchangeData(true);								// update other data
			}
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
		}

		private AppData Data;	// Reference to the application data object
    }
}