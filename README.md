#CleanAOP－－简介 [![Build][Build-state]][Build-url]    [![Gitter](https://badges.gitter.im/Jarvin-Guan/CleanAOP.svg)](https://gitter.im/Jarvin-Guan/CleanAOP?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
	作者：立地(欧文)
	邮箱：jarvin_g@126.com

####导语：
> &emsp;&emsp;[AOP](http://baike.baidu.com/link?url=xdZ6skwPK9cqfa1Rw_obkBGoic3f6aYyTBW2I3i967LeDiCOdkUK1ylc-I9pJ0EtKtZ3wF1YzgSONhlyYxREvflFosrs0lXxydMZDUjjhAS)为Aspect Oriented Programming的缩写。 意为：面向切面编程。将日志记录，性能统计，安全控制，事务处理，异常处理等代码从业务逻辑代码中划分出来，通过对这些行为的分离，将它们独立到非指导业务逻辑的方法中，进而改变这些行为的时候不影响业务逻辑的代码。  

##一：认识Aop

&emsp;&emsp;在日常的编程任务中，很多的代码都是进行一些通用的功能（日志、检测、一层处理等等），然后代码都是机械般的复制粘贴，实际上的业务逻辑代码只占不多的份额。那么，aop能更好的组织通用的代码、然后以标记的方式让某个方法切入，使得业务逻辑和通用代码分离，使其互不影响。

###使用Aop的优点
* 容易扩展新的切面。
* 业务逻辑与切面逻辑解耦合。
* 对修改封闭、对扩展开放。

###使用Aop的缺点
* 对于一些已存在修饰符的方法无法使用，需添加外围方法包含。

###CleanAop支持语言
![C#](http://d.pcs.baidu.com/thumbnail/36340eb0205ae3cff8352ee5f879d06e?fid=2605888136-250528-177262570783512&time=1446649200&sign=FDTAER-DCb740ccc5511e5e8fedcff06b081203-v2%2BYHRdRxL7E22pGPwPqcPTMEBA%3D&rt=sh&expires=2h&r=293473716&sharesign=unknown&size=c710_u500&quality=100)

###版本历史
####最新版本：v2.0.0
* v1.0.0:框架搭建完成、支持同步异步、提供Demo切面(错误捕获，log，时间记录)、前后切面选择。
* v2.0.0:
	1. 拦截面切入方式改变，优化代理类生成方式。
	2. 使用AOP的类不能有带参构造函数bug修复。

###哪里下载？
1. **[github地址](https://github.com/Jarvin-Guan/CleanAOP)**
2. **网盘下载:**
	* [v1.0.0](http://pan.baidu.com/s/1dD4pp1f)
	* [v2.0.0](http://pan.baidu.com/s/1o65ZbHS)

###Demo测试案例
1. 	**多切面、同步**

		[TryCatchAttrubute]
        [LogAopAttrubute]
        [TimeAop]
        public virtual void DoWord()
        {
            throw new Exception("错误测试");
            Debug.WriteLine("123");
        }

    结果：

    	开始捕捉异常（[TryCatchAttrubute]）
    	开始执行（[LogAopAttrubute]）
		2015/11/5 0:47:19（[TimeAop]）
		错误测试（异常捕获处理）
		执行中（[LogAopAttrubute]）
		执行结束,Void DoWord()方法（[LogAopAttrubute]）
		2015/11/4 23:47:19	[TimeAop]）
    	
2. **多切面、异步**

		[TryCatchAttrubute]
        [LogAopAttrubute]
        [TimeAop]
        public virtual async Task DoWord()
        {
            await GetValueAsync(1234.5123, 1.01);
            Debug.WriteLine("123");
            throw new Exception("错误测试");
            Debug.WriteLine("123");
        }

    结果：

    	开始捕捉异常（[TryCatchAttrubute]）
		开始执行（[LogAopAttrubute]）
		2015/11/5 1:05:23（[TimeAop]）
		执行中（[LogAopAttrubute]）
		123
		处理错误,错误信息为：错误测试（[TryCatchAttrubute]）
		执行结束,System.Threading.Tasks.Task DoWord()方法（[LogAopAttrubute]）
		2015/11/5 0:05:23（[TimeAop]）

[Build-state]: https://travis-ci.org/Jarvin-Guan/CleanAOP.svg?branch=master
[Build-url]: https://travis-ci.org/

