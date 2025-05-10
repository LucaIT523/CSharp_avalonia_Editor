
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MockerProject.Views;
using ReactiveUI;
using Color = Avalonia.Media.Color;
using FontFamily = Avalonia.Media.FontFamily;
using FontStyle = Avalonia.Media.FontStyle;
using Size = Avalonia.Size;

namespace MockerProject.ViewModels;

public class UIControlViewModel : ReactiveObject
{
    private UIControl m_UIControl;
    private MainWindowViewModel m_MainVM;
    private string m_strControl_Name = "Label";
    public string Control_Name
    {
        get => m_strControl_Name;
        set { this.RaiseAndSetIfChanged(ref m_strControl_Name, value); m_UIControl.m_strName = Control_Name; }
    } //Text
    private string m_text = "Label";
    public string text
    {
        get => m_text;
        set { this.RaiseAndSetIfChanged(ref m_text, value); m_UIControl.m_strText=text;  setFitSize();}
    }//Text
    private bool m_isEnabled = true;
    public bool isEnabled
    {
        get => m_isEnabled;
        set => this.RaiseAndSetIfChanged(ref m_isEnabled, value);
    }//Disable
    private string m_strControl_Tip;
    public string Control_Tip
    {
        get => m_strControl_Tip;
        set
        {
            this.RaiseAndSetIfChanged(ref m_strControl_Tip, value);
            m_UIControl.m_Tooltip = Control_Tip;
        }
    }//Tooltip
    public double m_opacity= 1;
    public double opacity
    {
        get => m_opacity;
        set
        {
            this.RaiseAndSetIfChanged(ref m_opacity, value);
            m_UIControl.m_Opacity = opacity;
        }
    }//Opacity
    private int m_nControl_sX;
    public int Control_sX
    {
        get => m_nControl_sX;
        set => this.RaiseAndSetIfChanged(ref m_nControl_sX, value);
    }//???
    private int m_nControl_sY;
    public int Control_sY
    {
        get => m_nControl_sY;
        set => this.RaiseAndSetIfChanged(ref m_nControl_sY, value);
    }//???
    private int m_width;
    public int width
    {
        get => m_width;
        set { this.RaiseAndSetIfChanged(ref m_width, value); m_UIControl.m_nWidth = width; }
    } //Width
    private int m_height;
    public int height
    {
        get => m_height;
        set { this.RaiseAndSetIfChanged(ref m_height, value); m_UIControl.m_nHeight = m_height; }
    } //Height
    private SolidColorBrush m_background = new SolidColorBrush(new Color(0, 255, 255, 255));
    public SolidColorBrush background
    {
        get => m_background;
        set { this.RaiseAndSetIfChanged(ref m_background, value); }
    } //Background
    private SolidColorBrush m_borderColor = new SolidColorBrush(new Color(255, 77, 77, 77));
    public SolidColorBrush borderColor
    {
        get => m_borderColor;
        set { this.RaiseAndSetIfChanged(ref m_borderColor, value);}
    } //Border_Color
    public ObservableCollection<int> List_Thickness { get; set; }
    public int w_nThicknessID = 0;
    public int ThicknessID
    {
        get
        {
            return w_nThicknessID;
        }
        set
        {
            if (value > -1)
            {
                borderThickness = new Thickness(List_Thickness[value],List_Thickness[value],List_Thickness[value],List_Thickness[value]);
            }
            this.RaiseAndSetIfChanged(ref w_nThicknessID, value);
        }
    }
    private Thickness m_borderThickness;
    public Thickness borderThickness
    {
        get => m_borderThickness;
        set { this.RaiseAndSetIfChanged(ref m_borderThickness, value); m_UIControl.m_BorderThickness = borderThickness; }
    } //Border Thickness
    public ObservableCollection<int> List_Round { get; set; }
    public int w_nRoundID = 0;
    public int RoundID
    {
        get
        {
            return w_nRoundID;
        }
        set
        {
            if (value > -1)
            {
                borderRound = new CornerRadius(List_Round[value],List_Round[value],List_Round[value],List_Round[value]);
            }
            this.RaiseAndSetIfChanged(ref w_nRoundID, value);
        }
    }
    private CornerRadius m_borderRound = new CornerRadius(3, 3, 3, 3);
    public CornerRadius borderRound
    {
        get => m_borderRound;
        set { this.RaiseAndSetIfChanged(ref m_borderRound, value); m_UIControl.m_BorderRound = borderRound; }
    } //Border Rounding
    private SolidColorBrush m_foreground = new SolidColorBrush(new Color(255, 33, 33, 33));
    public SolidColorBrush foreground
    {
        get => m_foreground;
        set => this.RaiseAndSetIfChanged(ref m_foreground, value);
    }//Foreground
    public ObservableCollection<int> List_FontSize { get; set; }
    public int w_nfontSizeID = 0;
    public int fontSizeID
    {
        get
        {
            return w_nfontSizeID;
        }
        set
        {
            if (value > -1)
            {
                fontSize = List_FontSize[value];
            }
            this.RaiseAndSetIfChanged(ref w_nfontSizeID, value);
        }
    }
    private int m_fontSize = 14 ;
    public int  fontSize
    {
        get => m_fontSize;
        set { 
            this.RaiseAndSetIfChanged(ref m_fontSize, value); m_UIControl.m_nFontSize = fontSize; 
            setFitSize(); }
    }//Text_FontSize
    
    private FontFamily m_fontFamily = "arial";
    public FontFamily fontFamily
    {
        get => m_fontFamily;
        set { this.RaiseAndSetIfChanged(ref m_fontFamily, value); m_UIControl.m_FontFamily = fontFamily; setFitSize(); }
    }//Text_FontFamily
    private bool m_bTextBold= false;
    public bool textBold
    {
        get => m_bTextBold;
        set
        {
            if (value)
                fontWeight = FontWeight.Bold;
            else
                fontWeight = FontWeight.Normal;
            this.RaiseAndSetIfChanged(ref m_bTextBold, value);
        }
    } //Text_Bold
    public FontWeight m_FontWeight = FontWeight.Normal;
    public FontWeight fontWeight
    {
        get => m_FontWeight;
        set { this.RaiseAndSetIfChanged(ref m_FontWeight, value); setFitSize(); }
    }//FontWeight
    private bool m_bTextItalic = false;
    public bool textItalic
    {
        get => m_bTextItalic;
        set
        {
            if (value)
                fontStyle = FontStyle.Italic;
            else
                fontStyle = FontStyle.Normal;
            this.RaiseAndSetIfChanged(ref m_bTextItalic, value);
        }
    } //Text_Italic
    public FontStyle m_FontStyle = FontStyle.Normal;
    public FontStyle fontStyle
    {
        get => m_FontStyle;
        set { this.RaiseAndSetIfChanged(ref m_FontStyle, value); setFitSize(); }
    }//FontStyle
    public bool m_IsFitVisible = false;
    public bool IsFitVisible
    {
        get => m_IsFitVisible;
        set => this.RaiseAndSetIfChanged(ref m_IsFitVisible, value);
    }//IsVisible_Fit
    public bool m_IsBorderVisible = true;
    public bool IsBorderVisible
    {
        get => m_IsBorderVisible;
        set => this.RaiseAndSetIfChanged(ref m_IsBorderVisible, value);
    }//IsVisible_Border
    public bool m_IsBorderColorVisible = true;
    public bool IsBorderColorVisible
    {
        get => m_IsBorderColorVisible;
        set => this.RaiseAndSetIfChanged(ref m_IsBorderColorVisible, value);
    }//IsVisible_BorderColor
    public bool m_IsBackgroundVisibel = true;
    public bool IsBackgroundVisible
    {
        get => m_IsBackgroundVisibel;
        set => this.RaiseAndSetIfChanged(ref m_IsBackgroundVisibel, value);
    }//IsVisible_BorderColor
    public bool m_IsFitWidth = false;
    public bool IsFitWidth
    {
        get => m_IsFitWidth;
        set => this.RaiseAndSetIfChanged(ref m_IsFitWidth, value);
    }//IsEnable_FitWidth
    public bool m_IsFitHeight = false;
    public bool IsFitHeight
    {
        get => m_IsFitHeight;
        set => this.RaiseAndSetIfChanged(ref m_IsFitHeight, value);
    }//IsEnable_FitHeight
    public bool m_ReadOnlyHeight = false;
    public bool ReadOnlyHeight
    {
        get => m_ReadOnlyHeight;
        set => this.RaiseAndSetIfChanged(ref m_ReadOnlyHeight, value);
    }//IsReadOnly_Height

    public int w_nPageID = 0;
    public int PageID
    {
        get => w_nPageID;
        set => this.RaiseAndSetIfChanged(ref w_nPageID, value);
    }

    public object IsTextPropertiesVisible { get; set; }

    public void setMainVM(MainWindowViewModel mainVM)
    {
        m_MainVM = mainVM;
    }
    private int[] m_listTextSize = new int[]{6,7,8,9,10,11,12,14,16,18,21,24,36,48,60,72};
    public UIControlViewModel(UIControl uiControl)
    {
        m_UIControl = uiControl;
        List_FontSize =new ObservableCollection<int>();
        List_Thickness =new ObservableCollection<int>();
        List_Round =new ObservableCollection<int>();
        
        //if (uiControl.GetType() == typeof(LabelControl))
        {
            for (int i = 0; i < m_listTextSize.Length; i++)
            {
                List_FontSize.Add(m_listTextSize[i]);
            }
            fontSizeID = 7;
            for (int i = 0; i < 20; i++)
            {
                List_Thickness.Add(i);
                List_Round.Add(i);
            }
            ThicknessID = 0;
            RoundID = 0;
        }
        if (uiControl.GetType() == typeof(ButtonControl))
        {
            
        }

        if (uiControl.GetType() == typeof(LabelControl))
        {
            IsFitVisible = true;
            IsBorderVisible = IsBorderColorVisible = false;
        }
        if (uiControl.GetType() == typeof(EditControl))
        {
            IsFitVisible = IsBorderVisible = false;
            ReadOnlyHeight = true;
        }
    }

    public void setFitSize()
    {
        TextBlock w_text = new TextBlock();
        w_text.Text = m_text;
        w_text.FontFamily = m_fontFamily;
        w_text.FontSize = m_fontSize;
        w_text.FontWeight = m_FontWeight;
        w_text.FontStyle = m_FontStyle;
        w_text.TextWrapping = TextWrapping.Wrap;
        w_text.Width = double.NaN;
        w_text.Measure(Size.Infinity);
        if (ReadOnlyHeight)
        {
            m_UIControl.m_nHeight = m_UIControl.DesiredSize.Height;
        }
        else
        {
            if(IsFitWidth)
            {
                m_UIControl.m_nWidth = w_text.DesiredSize.Width;
                width = (int)m_UIControl.m_nWidth;
                if (m_MainVM.m_wndUIProperty != null)
                    m_MainVM.m_wndUIProperty.Size_W.Text = m_UIControl.m_nWidth.ToString();
            }
            if (IsFitHeight && IsFitWidth)
            {
                m_UIControl.m_nHeight = w_text.DesiredSize.Height;
                height = (int)m_UIControl.m_nHeight;
                if (m_MainVM.m_wndUIProperty != null)
                {
                    m_MainVM.m_wndUIProperty.Size_H.Text = m_UIControl.m_nHeight.ToString();
                    m_MainVM.m_wndUIProperty.Size_W.Text = m_UIControl.m_nWidth.ToString();
                }
            }
            else if (IsFitHeight)
            {
                w_text.Width = m_width;
                w_text.Height = double.NaN;
                w_text.Measure(Size.Infinity);
                m_UIControl.m_nHeight= w_text.DesiredSize.Height;
                height = (int)m_UIControl.m_nHeight;
                if (m_MainVM.m_wndUIProperty != null)
                    m_MainVM.m_wndUIProperty.Size_H.Text = m_UIControl.m_nHeight.ToString();
            }
        }
        //TextReader.MeasureText(m_text, new Font(m_fontFamily.ToString(), m_fontSize));
    }
}