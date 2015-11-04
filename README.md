#CleanAOP－－简介
####导语：
> [AOP](http://baike.baidu.com/link?url=xdZ6skwPK9cqfa1Rw_obkBGoic3f6aYyTBW2I3i967LeDiCOdkUK1ylc-I9pJ0EtKtZ3wF1YzgSONhlyYxREvflFosrs0lXxydMZDUjjhAS)为Aspect Oriented Programming的缩写。 意为：面向切面编程。将日志记录，性能统计，安全控制，事务处理，异常处理等代码从业务逻辑代码中划分出来，通过对这些行为的分离，将它们独立到非指导业务逻辑的方法中，进而改变这些行为的时候不影响业务逻辑的代码。  

##一：认识Aop

在日常的编程任务中，很多的代码都是进行一些通用的功能（日志、检测、一层处理等等），然后代码都是机械般的复制粘贴，实际上的业务逻辑代码只占不多的份额。那么，aop能更好的组织通用的代码、然后以标记的方式让某个方法切入，使得业务逻辑和通用代码分离，使其互不影响。

###使用Aop的优点
* 容易扩展新的切面。
* 业务逻辑与切面逻辑解耦合。
* 对修改封闭、对扩展开放。

###支持语言
![C#](http://image.baidu.com/search/detail?ct=503316480&z=0&ipn=d&word=C%23%E5%9B%BE%E6%A0%87&step_word=&pn=3&spn=0&di=138822950310&pi=&rn=1&tn=baiduimagedetail&is=&istype=0&ie=utf-8&oe=utf-8&in=&cl=2&lm=-1&st=-1&cs=2323039389%2C759035628&os=819911234%2C259100666&adpicid=0&ln=1994&fr=&fmq=1446649563780_R&ic=0&s=undefined&se=&sme=&tab=0&width=&height=&face=undefined&ist=&jit=&cg=&bdtype=0&objurl=http%3A%2F%2Fa1.att.hudong.com%2F72%2F30%2F01200000024274136323304814525.jpg&fromurl=ippr_z2C%24qAzdH3FAzdH3Fp7rtwg_z%26e3Bi715g2_z%26e3Bv54AzdH3Ftrw1AzdH3Fw8_0d_na_a8daaaaaad9d098nmndnna9b89cdc_3r2_z%26e3Bip4s&gsm=0)
