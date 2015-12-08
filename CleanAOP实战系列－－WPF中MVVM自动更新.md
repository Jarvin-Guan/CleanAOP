#CleanAOP实战系列－－WPF中MVVM自动更新
	
	作者: 立地
	邮箱: jarvin_g@126.com
	QQ:  511363759
	
CleanAOP介绍:[https://github.com/Jarvin-Guan/CleanAOP](https://github.com/Jarvin-Guan/CleanAOP)

##前言

 讲起WPF，开发模式MVVM是必不可少的，使用MVVM模式以后可以在View中写界面，需要使用到的数据则使用绑定的方式写到标签中，那么控制权就放到了ViewModel中，那么有一个需求是每一个使用MVVM者都会有的，就是在后台改变ViewModel的属性时，同时使前台View绑定的标签内容得到相应更新变动。
 
##定义属性方式对比
 *  **传统方式**

		private string m_Name = "";
        public string Name
        {
            set
            { 
				if(value!=m_Name)
				{
                	m_Name = value; 
			    	OnPropertyChanged("Name"); 
			    }
			}
            get { return m_Name; }
        }

 *  **使用CleanAOP后**

		public virtual string Name { set; get; }

**对比总结:**
	使用传统方式使用了一大堆累赘的代码，使用CleanAOP后，简单、方便。
	
	
##实战（使用CleanAOP使属性自动更新）


 1. 下载[CleanAOP2.0.0](http://yun.baidu.com/s/1o65ZbHS),并且引用dll到项目中。
 3. Notice更新类:
 
 		public class Notice : INotifyPropertyChanged, ICommand
    	{

       	#region [     用于实现绑定的属性基础      ]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
        #endregion

        #region [     用于实现绑定的命令基础     ]
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc(parameter);
            }

            return true;


        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                this.ExecuteAction(parameter);

            }
        }

        public Func<object, bool> CanExecuteFunc { set; get; }

        public Action<object> ExecuteAction { set; get; }
        #endregion
    	}
 2. 定义ViewModel:
 
 		[PropertyNotifyIntercept]//添加属性通知标签，表示该类接入属性通知拦截器。
    	//继承Notice
    	public class MainWindowVM : Notice
    	{
    	
        	//定义Name属性
        	public virtual string Name { set; get; } = "jarvin";

        }
 3. 界面上绑定该属性
 		
 		<TextBox Text="{Binding Name}"></TextBox>
 4. 设置DataContext
 		
 		public MainWindow()
        {
            InitializeComponent();
            this.DataContext = InterceptClassFactory.GetInterceptClass<MainWindowVM>();
        }

 5. 修改MainWindowVM的Name的值，这时候界面上会自动做出更新！！

 
## 总结

感谢大家使用CleanAOP,使用该方式也可以绑定命令，绑定命令的方式在Demo中会有展示，希望能给大家带来方便。大家可以[下载Demo](http://pan.baidu.com/s/1ntxTH5B)来调试。


