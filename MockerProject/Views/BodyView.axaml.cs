using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using DynamicData;
using MockerProject.ViewModels;

namespace MockerProject.Views;

public partial class BodyView : UserControl
{
    UIControl m_Control = null;
    public BodyView()
    {
        InitializeComponent();
        this.Toolbar.UIControl.Button.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.Button.PointerExited += onMouseExit;
        this.Toolbar.UIControl.TextBox.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.TextBox.PointerExited += onMouseExit;
        this.Toolbar.UIControl.Label.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.Label.PointerExited += onMouseExit;
        this.Toolbar.UIControl.Title.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.Title.PointerExited += onMouseExit;
        this.Toolbar.UIControl.Image.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.Image.PointerExited += onMouseExit;
        this.Toolbar.UIControl.Radio.PointerPressed += onMouseUp;
        this.Toolbar.UIControl.Radio.PointerExited += onMouseExit;
        this.PointerMoved += onMouseMove;
        this.PointerReleased += onMouseDown;
    }

    private void onMouseExit(object sender, PointerEventArgs e)
    {
        MainWindowViewModel mainViewModel = (MainWindowViewModel)this.DataContext;
        mainViewModel.m_UIControlType = 0;
    }

    private void onMouseUp(object sender, PointerPressedEventArgs e)
    {
        MainWindowViewModel mainViewModel = (MainWindowViewModel)this.DataContext;
        var properties = e.GetCurrentPoint(this).Properties;
        if (properties.IsLeftButtonPressed && sender.GetType() == typeof(Image))
        {
            Control w_Control = (Control)sender;
            if (w_Control.Name == "Button")
            {
                mainViewModel.m_UIControlType = 2;
            }
            else if (w_Control.Name == "TextBox")
            {
                    
                mainViewModel.m_UIControlType = 3;
            }
            else if (w_Control.Name == "Label")
            {
                mainViewModel.m_UIControlType = 4;
            }
            else if (w_Control.Name == "Title")
            {
                mainViewModel.m_UIControlType = 5;
            }
            else if (w_Control.Name == "Image")
            {
                mainViewModel.m_UIControlType = 6;
            }
            else if (w_Control.Name == "Radio")
            {
                mainViewModel.m_UIControlType = 7;
            }
            else
            {
                mainViewModel.m_UIControlType = 0;
            }
        }
        else
        {
            mainViewModel.m_UIControlType = 0;
        }
        return;
    }
    private void onMouseMove(object sender, PointerEventArgs e)
    {
        MainWindowViewModel mainViewModel = (MainWindowViewModel)this.DataContext;
        int w_UIControlType = mainViewModel.m_UIControlType;
        int w_nSelectedUIControl = mainViewModel.m_nSelectedUIControl;
        var properties = e.GetCurrentPoint(this).Properties;
        if (properties.IsLeftButtonPressed)
        {
            
            var sX = e.GetPosition(this.Work.Screen).X;
            var sY = e.GetPosition(this.Work.Screen).Y;
            if (w_UIControlType > 0)
            {
                if (m_Control == null)
                {
                    if (w_UIControlType == 1)
                    {
                        mainViewModel.PG_RW = (int)sX - mainViewModel.PG_X;
                        mainViewModel.PG_RH = (int)sY - mainViewModel.PG_Y;
                        if (mainViewModel.PF_Ang == 0)
                        {
                            if (mainViewModel.PG_RW < mainViewModel.PG_W)
                                mainViewModel.PG_RW = mainViewModel.PG_W;
                            if (mainViewModel.PG_RH < mainViewModel.PG_H)
                                mainViewModel.PG_RH = mainViewModel.PG_H;
                        }
                        else
                        {
                            if (mainViewModel.PG_RW < mainViewModel.PG_H)
                                mainViewModel.PG_RW = mainViewModel.PG_H;
                            if (mainViewModel.PG_RH < mainViewModel.PG_W)
                                mainViewModel.PG_RH = mainViewModel.PG_W;
                        }
                        
                    }
                    else if (w_UIControlType == 2)
                    {
                        m_Control = new ButtonControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setName("Button");
                        m_Control.setText("Button");
                        m_Control.setSize(100, 30);
                        m_Control.setFontSizeID(7);
                        m_Control.setType(w_UIControlType);
                        //m_Control.setBackground(new SolidColorBrush(new Color(255, 200, 200, 200)));
                    }
                    else if (w_UIControlType == 3)
                    {
                        m_Control = new EditControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setName("TextBox");
                        m_Control.setText("This is TextBox");
                        m_Control.setWidth(200);
                        m_Control.setFontSizeID(3);
                        m_Control.setType(w_UIControlType);
                        //m_Control.setBackground(new SolidColorBrush(new Color(255,255,255,255)));
                    }
                    else if(w_UIControlType == 4)
                    {
                        m_Control = new LabelControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setName("Label");
                        m_Control.setText("This is label");
                        m_Control.setSize(100, 30);
                        m_Control.setFontSizeID(7);
                        m_Control.setType(w_UIControlType);
                    }
                    else if(w_UIControlType == 5)
                    {
                        m_Control = new LabelControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setName("Title");
                        m_Control.setText("TITLE OF DESIGN");
                        m_Control.setSize(300, 50);
                        m_Control.setFontSizeID(10);
                        m_Control.setType(w_UIControlType);
                    }
                    else if(w_UIControlType == 6)
                    {
                        m_Control = new ImageControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setName("Image");
                        
                        m_Control.setSize(100, 100);
                        m_Control.setText("Image");
                        m_Control.setType(w_UIControlType);
                    }
                    else if(w_UIControlType == 7)
                    {
                        m_Control = new RadioControl();
                        m_Control.setMainVM(mainViewModel);
                        m_Control.setType(w_UIControlType);
                    }
                    if (m_Control != null)
                    {
                        mainViewModel.WorkScreen.screenCanvas.Children.Add(m_Control);
                    }
                        
                }

                if (m_Control != null)
                {
                    double w_CsX = 0 ,w_CsY = 0;
                    Rect w_CRect =m_Control.getRect();
                    w_CsX  = sX - w_CRect.Width / 2;
                    w_CsY = sY - w_CRect.Height / 2;
                    m_Control.setPosition(w_CsX, w_CsY);
                    
                    //Canvas.SetLeft(m_Control, w_CsX);
                    //Canvas.SetTop(m_Control, w_CsY);
                }
                //MainWindowViewModel myview = (MainWindowViewModel)this.DataContext;
                //myview.Page_Y = 0;
            }
            /*else if (w_nSelectedUIControl > 0)
            {
                m_Control = (UIControl)mainViewModel.WorkScreen.screenCanvas.Children[w_nSelectedUIControl];
                double w_CsX = 0 ,w_CsY = 0;
                w_CsX  = sX - m_Control.sX;
                w_CsY = sY - m_Control.sY;
                
                //Canvas.SetLeft(m_Control, w_CsX);
                //Canvas.SetTop(m_Control, w_CsY);
                m_Control.setPosition(w_CsX, w_CsY);
                /*if(m_Control.GetType() == typeof(ButtonControl))
                    ((ButtonControl)m_Control).setPoint(sX, sY);
                else if(m_Control.GetType() == typeof(EditControl))
                    ((EditControl)m_Control).setPoint(sX, sY);
                else if(m_Control.GetType() == typeof(LabelControl))
                    ((LabelControl)m_Control).setPoint(sX, sY);
                else if(m_Control.GetType() == typeof(ImageControl))
                    ((ImageControl)m_Control).setPoint(sX, sY);
                else if(m_Control.GetType() == typeof(RadioControl))
                    ((RadioControl)m_Control).setPoint(sX, sY);#1#
            }*/
        }
        
    }

    private void onMouseDown(object sender, PointerEventArgs e)
    {
        MainWindowViewModel mainViewModel = (MainWindowViewModel)this.DataContext;
        int w_UIControlType = mainViewModel.m_UIControlType;
        int w_nSelectedUIControl = mainViewModel.m_nSelectedUIControl;
        var properties = e.GetCurrentPoint(this).Properties;
        //if (properties.IsLeftButtonPressed)
        {
            var sX = e.GetPosition(this.Work.Screen).X;
            var sY = e.GetPosition(this.Work.Screen).Y;
            if (w_UIControlType > 0)
            {
                if (m_Control != null)
                {
                    stControlHistory w_ControlHistory = new stControlHistory();
                    w_ControlHistory.Index = mainViewModel.WorkScreen.screenCanvas.Children.Count-1;
                    w_ControlHistory.type = m_Control.GetType();
                    w_ControlHistory.Cmd = "New";
                    w_ControlHistory.id = w_UIControlType;
                    w_ControlHistory.curInfo = m_Control;
                    mainViewModel.WorkScreen.m_UndoList.Add(w_ControlHistory);
                }
            }
            else if (w_nSelectedUIControl > 0)
            {
                if (m_Control != null)
                {
                    stControlHistory w_ControlHistory = new stControlHistory();
                    w_ControlHistory.Index = w_nSelectedUIControl;
                    w_ControlHistory.Cmd = "Change";
                    w_ControlHistory.type = m_Control.GetType();
                    //w_ControlHistory.id = w_UIControlType;
                    w_ControlHistory.curInfo = m_Control;
                    mainViewModel.WorkScreen.m_UndoList.Add(w_ControlHistory);
                }
            }
        }
        mainViewModel.setScreenSmallView(mainViewModel.SmallScreenID);
        m_Control = null;
    }

}