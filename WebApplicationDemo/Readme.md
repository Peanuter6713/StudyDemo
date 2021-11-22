# Autofac 支持控制器属性注入  
控制器是一个类，控制器的实例其实是IControllerActivator来创建的  
1. 得让控制器获取实例  
2. 注册控制器抽象和具体的关系  

	 var controllerTypesAssembly =  
 
3. 在控制器内定义属性
4. 扩展，自己控制哪些属性需要做依赖注入

# Autofac抽象多实现问题  
1. 一个抽象多个实例，都注册了，通过构造函数用抽象类型来获取实例，哪个后面注册就获取哪个，覆盖型；
2. 一个抽象多个实例，都注册了，可以通过一个IEnumerable<抽象类型>,当做构造函数参数，可以获取到所有注册的具体的实例。
3. 注册一个抽象的多个实例资源，如下方式注册，可以在控制器的构造函数中，使用具体实现类型作为参数类型，可以匹配到不同的类型实例。  
	
		containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t =>
            t.IsAssignableTo<IServiceA>()));



