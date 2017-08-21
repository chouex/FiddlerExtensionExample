using System;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Fiddler;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

 

public class RequestInspector : Inspector2, IRequestInspector2
{
    TextBox myControl;
    private byte[] m_entityBody;
    private bool m_bDirty;

    private bool m_bReadOnly;

    public bool bReadOnly
    {
        get { return m_bReadOnly; }
        set
        {
            m_bReadOnly = value;
            // TODO: You probably also want to turn your visible control CONFIG.colorDisabledEdit (false) or WHITE (true) here depending on the value being passed in.   
        }
    }

    public void Clear()
    {
        m_entityBody = null;
        m_bDirty = false;
        myControl.Text = "";
    }

    public RequestInspector()
    {
        // TODO: Add constructor logic here
    }

    public HTTPRequestHeaders headers
    {
        get { return null; // Return null if your control doesn't allow header editing.
        }
        set { }
    }

    public byte[] body
    {
        get { return System.Text.Encoding.UTF8 .GetBytes(myControl.Text.Replace("_only_modify_in_inspector","_removed")); }
        set
        {
            // Here's where the action is.  It's time to update the visible display of the text
            m_entityBody = value;

            if (null != m_entityBody)
            {
                var text = System.Text.Encoding.UTF8.GetString(m_entityBody);
            
                myControl.Text = text+"_only_modify_in_inspector";
                // TODO: Use correct encoding based on content header.
            }
            else
            {
                myControl.Text = "";
            }

            m_bDirty = false;
            // Note: Be sure to have an OnTextChanged handler for the textbox which sets m_bDirty to true!
        }
    }

    public bool bDirty
    {
        get { return m_bDirty; }
    }

    public override int GetOrder()
    {
        return 0;
    }

    public override void AddToTab(System.Windows.Forms.TabPage o)
    {
        myControl = new TextBox(); // Essentially the TextView class is simply a usercontrol containing a textbox.
        myControl.Height = o.Height;
        myControl.Multiline = true;
        myControl.ScrollBars = ScrollBars.Vertical;
        myControl.TextChanged += TextBox1_TextChanged;
        o.Text = "TextViewExample";
        o.Controls.Add(myControl);
        o.Controls[0].Dock = DockStyle.Fill;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        m_bDirty = true;
    }
}