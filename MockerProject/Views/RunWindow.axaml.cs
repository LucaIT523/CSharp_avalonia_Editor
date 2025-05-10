using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using MockerProject.ViewModels;
using MockerProject.Views;
using System.Drawing;
using Avalonia.Styling;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using FontStyle = Avalonia.Media.FontStyle;
using Image = Avalonia.Controls.Image;

namespace MockerProject
{
    public partial class RunWindow : Window
    {
        private MainWindowViewModel m_MainVM;
        public RunWindow()
        {
            InitializeComponent();
        }
        public void setMainViewModel(MainWindowViewModel mainViewModel)
        {
            this.DataContext = mainViewModel;
            m_MainVM = mainViewModel;
            Control w_Control = null;
            
            SetControltoCanvas(0);
        }

        public void Init()
        {
            for(int i=0; i<this.screenCanvas.Children.Count;)
                this.screenCanvas.Children.RemoveAt(0);
        }

        private int GetIdtoPageName(string name)
        {
            int id = -1;
            for (int i = 0; i < m_MainVM.m_lstWorkScreen.Count; i++)
            {
                if (name == m_MainVM.m_lstWorkScreen[i].m_strName)
                    return i;
            }

            return id;
        }
        private void SetControltoCanvas(int id)
        {
            Control w_Control = null;
            
            this.rectangle.Width = m_MainVM.m_lstWorkScreen[id].m_Size.Width;
            this.rectangle.Height = m_MainVM.m_lstWorkScreen[id].m_Size.Height;
            this.rectangle.Fill = m_MainVM.m_lstWorkScreen[id].m_background;
            this.rectangle.Opacity = m_MainVM.m_lstWorkScreen[id].m_Opacity;

            for (int i = 3; i < m_MainVM.m_lstWorkScreen[id].screenCanvas.Children.Count; i++)
            {
                UIControl w_UIControl = (UIControl)m_MainVM.m_lstWorkScreen[id].screenCanvas.Children[i];
                if (w_UIControl.m_nUIControlType == 2)
                {
                    w_Control = new Button();
                    ((Button)w_Control).HorizontalContentAlignment = HorizontalAlignment.Center;
                    ((Button)w_Control).VerticalContentAlignment = VerticalAlignment.Center;
                    ((Button)w_Control).Padding = new Thickness(0);
                    ((Button)w_Control).Content = w_UIControl.m_strText;
                    ((Button)w_Control).FontSize = w_UIControl.m_nFontSize;
                    ((Button)w_Control).Opacity = w_UIControl.m_Opacity;
                    ToolTip.SetTip(w_Control, w_UIControl.m_Tooltip);
                    ((Button)w_Control).Background = w_UIControl.m_Background;
                    ((Button)w_Control).Foreground = w_UIControl.m_Foreground;
                    ((Button)w_Control).BorderThickness = w_UIControl.m_BorderThickness;
                    ((Button)w_Control).CornerRadius = w_UIControl.m_BorderRound;
                    ((Button)w_Control).BorderBrush = w_UIControl.m_BorderColor;
                    ((Button)w_Control).FontFamily = w_UIControl.m_FontFamily;
                    if (w_UIControl.m_bBold)
                        ((Button)w_Control).FontWeight = FontWeight.Bold;
                    if (w_UIControl.m_bItalic)
                        ((Button)w_Control).FontStyle = FontStyle.Italic;
                    ((Button)w_Control).IsEnabled = !w_UIControl.m_bDisable;
                    if (w_UIControl.m_TapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_TapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Button)w_Control).AddHandler(Button.TappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_DTapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_DTapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Button)w_Control).AddHandler(Button.DoubleTappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_HPressEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_HPressEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Button)w_Control).AddHandler(Button.HoldingEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_SwipeLeftEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_SwipeLeftEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Button)w_Control).AddHandler(Button.PointerMovedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                }
                else if (w_UIControl.m_nUIControlType == 3)
                {
                    w_Control = new TextBox();
                    ((TextBox)w_Control).Text = w_UIControl.m_strText;
                    ((TextBox)w_Control).FontSize = w_UIControl.m_nFontSize;
                    ((TextBox)w_Control).Opacity = w_UIControl.m_Opacity;
                    ToolTip.SetTip(w_Control, w_UIControl.m_Tooltip);
                    ((TextBox)w_Control).Background = w_UIControl.m_Background;
                    ((TextBox)w_Control).Foreground = w_UIControl.m_Foreground;
                    ((TextBox)w_Control).BorderThickness = w_UIControl.m_BorderThickness;
                    ((TextBox)w_Control).CornerRadius = w_UIControl.m_BorderRound;
                    ((TextBox)w_Control).BorderBrush = w_UIControl.m_BorderColor;
                    ((TextBox)w_Control).FontFamily = w_UIControl.m_FontFamily;
                    if (w_UIControl.m_bBold)
                        ((TextBox)w_Control).FontWeight = FontWeight.Bold;
                    if (w_UIControl.m_bItalic)
                        ((TextBox)w_Control).FontStyle = FontStyle.Italic;
                    ((TextBox)w_Control).IsEnabled = !w_UIControl.m_bDisable;
                    if (w_UIControl.m_TapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_TapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBox)w_Control).AddHandler(TextBox.TappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_DTapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_DTapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBox)w_Control).AddHandler(TextBox.DoubleTappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_HPressEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_HPressEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBox)w_Control).AddHandler(TextBox.HoldingEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_SwipeLeftEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_SwipeLeftEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBox)w_Control).AddHandler(TextBox.PointerMovedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }

                }
                else if (w_UIControl.m_nUIControlType == 4 || w_UIControl.m_nUIControlType == 5)
                {
                    w_Control = new TextBlock();
                    ((TextBlock)w_Control).Text = w_UIControl.m_strText;
                    ((TextBlock)w_Control).FontSize = w_UIControl.m_nFontSize;
                    ((TextBlock)w_Control).Opacity = w_UIControl.m_Opacity;
                    ToolTip.SetTip(w_Control, w_UIControl.m_Tooltip);
                    ((TextBlock)w_Control).Background = w_UIControl.m_Background;
                    ((TextBlock)w_Control).Foreground = w_UIControl.m_Foreground;
                    ((TextBlock)w_Control).FontFamily = w_UIControl.m_FontFamily;
                    if (w_UIControl.m_bBold)
                        ((TextBlock)w_Control).FontWeight = FontWeight.Bold;
                    if (w_UIControl.m_bItalic)
                        ((TextBlock)w_Control).FontStyle = FontStyle.Italic;
                    ((TextBlock)w_Control).IsEnabled = !w_UIControl.m_bDisable;
                    if (w_UIControl.m_TapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_TapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBlock)w_Control).AddHandler(TextBlock.TappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_DTapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_DTapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBlock)w_Control).AddHandler(TextBlock.DoubleTappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_HPressEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_HPressEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBlock)w_Control).AddHandler(TextBlock.HoldingEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_SwipeLeftEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_SwipeLeftEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((TextBlock)w_Control).AddHandler(TextBlock.PointerMovedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }

                }
                else if (w_UIControl.m_nUIControlType == 6)
                {
                    w_Control = new Image();
                    ((Image)w_Control).Opacity = w_UIControl.m_Opacity;
                    ToolTip.SetTip(w_Control, w_UIControl.m_Tooltip);
                    ((Image)w_Control).Source = new Bitmap(w_UIControl.m_strSrc);
                    //((Image)w_Control).Text = w_UIControl.m_strText;
                    if (w_UIControl.m_TapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_TapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Image)w_Control).AddHandler(Image.TappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_DTapEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_DTapEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Image)w_Control).AddHandler(Image.DoubleTappedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_HPressEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_HPressEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Image)w_Control).AddHandler(Image.HoldingEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }
                    if (w_UIControl.m_SwipeLeftEvent != null)
                    {
                        int w_EventID = GetIdtoPageName(w_UIControl.m_SwipeLeftEvent);
                        if(w_EventID !=-1 && w_EventID !=id )
                            ((Image)w_Control).AddHandler(Image.PointerMovedEvent, (sender, e) =>
                            {
                                Init();
                                SetControltoCanvas(w_EventID);
                            }, handledEventsToo: true);
                    }

                }
                else continue;
                w_Control.Width = w_UIControl.m_nWidth;
                w_Control.Height = w_UIControl.m_nHeight;
                Canvas.SetTop(w_Control, w_UIControl.m_nPositionY);
                Canvas.SetLeft(w_Control, w_UIControl.m_nPositionX);
                this.screenCanvas.Children.Add(w_Control);
                this.screenCanvas.Width = m_MainVM.m_lstWorkScreen[id].m_Size.Width;
                this.screenCanvas.Height = m_MainVM.m_lstWorkScreen[id].m_Size.Height;
            }
        }
    }
}
