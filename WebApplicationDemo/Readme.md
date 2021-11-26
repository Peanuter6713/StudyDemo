# Autofac 支持控制器属性注入  
控制器是一个类，控制器的实例其实是IControllerActivator来创建的  
1. 得让控制器获取实例  

2. 注册控制器抽象和具体的关系  

    ```
    var controllerTypesAssembly =  
    ```

3. 在控制器内定义属性

4. 扩展，自己控制哪些属性需要做依赖注入

# Autofac抽象多实现问题  
1. 一个抽象多个实例，都注册了，通过构造函数用抽象类型来获取实例，哪个后面注册就获取哪个，覆盖型；
2. 一个抽象多个实例，都注册了，可以通过一个IEnumerable<抽象类型>,当做构造函数参数，可以获取到所有注册的具体的实例。
3. 注册一个抽象的多个实例资源，如下方式注册，可以在控制器的构造函数中，使用具体实现类型作为参数类型，可以匹配到不同的类型实例。  
	
	```c#
   containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t =>
        t.IsAssignableTo<IServiceA>()));
   ```



# Autofac 支持 AOP

AOP面向切面编程：不用修改之前代码的基础上，可以动态的在某个动作之前加一些操作动态在某一个动作之后做点事情

1.  Nuget 引入 Castle.Core程序集 + Autofac Extras DynamicProxy

2.  在服务的抽象上（interface）增加特性  [Intercept(typeof(CustomAutofacAop))]

3.  注册支持AOP扩展的类

   ```c#
   containerBuilder.RegisterType(typeof(CustomAutofacAop));
   ```

4. 注册服务的时候，需要调用EnableInterfaceInterceptors,标记说明当前服务获取实例后可以支持AOP   

# Autofac支持AOP-2

注意：防止实现某个接口的所有类都支持AOP

EnableInterfaceInterceptors + 抽象标记特性 [Intercept(typeof(CustomAutofacAop))]，只要实现了这个抽象就可以支持AOP

EnableClassInterceptors + 实现类标记特性[Intercept(typeof(CustomAutofacAop))]，只有标记了这个特性的，才能够支持AOP

如果使用 EnableClassInterceptors 来支持AOP，实现类中支持AOP的方法必须为虚方法
