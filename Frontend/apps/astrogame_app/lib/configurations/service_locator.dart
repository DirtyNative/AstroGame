import 'package:get_it/get_it.dart';

/// Wrapper class around any dependency Injection Framework for easier access
class ServiceLocator {
  static final ServiceLocator _instance = ServiceLocator._internal();
  factory ServiceLocator() => _instance;

  static final _getIt = GetIt.instance;

  ServiceLocator._internal();

  /// registers a type as Singleton by passing an [instance] of that type
  /// that will be returned on each call of [get] on that type
  /// [T] type to register
  /// [instanceName] if you provide a value here your instance gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  /// If [signalsReady] is set to `true` it means that the future you can get from `allReady()`
  /// cannot complete until this this instance was signalled ready by calling [signalsReady(instance)].
  static void registerSingleton<T extends Object>(
    T instance, {
    String? instanceName,
    bool? signalsReady,
    DisposingFunc<T>? dispose,
  }) {
    _getIt.registerSingleton<T>(
      instance,
      instanceName: instanceName,
      signalsReady: signalsReady,
      dispose: dispose,
    );
  }

  /// registers a type as Singleton by passing an factory function of that type
  /// that will be called on each call of [get] on that type
  /// [T] type to register
  /// [instanceName] if you provide a value here your instance gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  /// [dependsOn] if this instance depends on other registered  Singletons before it can be initilaized
  /// you can either orchestrate this manually using [isReady()] or pass a list of the types that the
  /// instance depends on here. [factoryFunc] won't get executed till this types are ready.
  /// [func] is called
  /// If [signalsReady] is set to `true` it means that the future you can get from `allReady()`
  /// cannot complete until this this instance was signalled ready by calling [signalsReady(instance)].
  static void registerSingletonWithDependencies<T extends Object>(
    FactoryFunc<T> factoryFunc, {
    String? instanceName,
    Iterable<Type>? dependsOn,
    bool? signalsReady,
    DisposingFunc<T>? dispose,
  }) {
    _getIt.registerSingletonWithDependencies(
      factoryFunc,
      instanceName: instanceName,
      dependsOn: dependsOn,
      signalsReady: signalsReady,
      dispose: dispose,
    );
  }

  /// registers a type as Singleton by passing an asynchronous factory function which has to return the instance
  /// that will be returned on each call of [get] on that type.
  /// Therefore you have to ensure that the instance is ready before you use [get] on it or use [getAsync()] to
  /// wait for the completion.
  /// You can wait/check if the instance is ready by using [isReady()] and [isReadySync()].
  /// [factoryfunc] is executed immediately if there are no dependencies to other Singletons (see below).
  /// As soon as it returns, this instance is marked as ready unless you don't set [signalsReady==true]
  /// [instanceName] if you provide a value here your instance gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  /// [dependsOn] if this instance depends on other registered  Singletons before it can be initilaized
  /// you can either orchestrate this manually using [isReady()] or pass a list of the types that the
  /// instance depends on here. [factoryFunc] won't get  executed till this types are ready.
  /// If [signalsReady] is set to `true` it means that the future you can get from `allReady()`  cannot complete until this
  /// this instance was signalled ready by calling [signalsReady(instance)]. In that case no automatic ready signal
  /// is made after completion of [factoryfunc]
  static void registerSingletonAsync<T extends Object>(
    FactoryFuncAsync<T> factoryfunc, {
    String? instanceName,
    Iterable<Type>? dependsOn,
    bool? signalsReady,
    DisposingFunc<T>? dispose,
  }) {
    _getIt.registerSingletonAsync<T>(
      factoryfunc,
      instanceName: instanceName,
      dependsOn: dependsOn,
      signalsReady: signalsReady,
      dispose: dispose,
    );
  }

  /// registers a type so that a new instance will be created on each call of [get] on that type
  /// [T] type to register
  /// [factoryfunc] factory function for this type
  /// [instanceName] if you provide a value here your factory gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  static void registerFactory<T extends Object>(FactoryFunc<T> factoryfunc,
      {String? instanceName}) {
    _getIt.registerFactory<T>(factoryfunc, instanceName: instanceName);
  }

  /// registers a type so that a new instance will be created on each call of [get] on that type based on
  /// up to two parameters provided to [get()]
  /// [T] type to register
  /// [P1] type of  param1
  /// [P2] type of  param2
  /// if you use only one parameter pass void here
  /// [factoryfunc] factory function for this type that accepts two parameters
  /// [instanceName] if you provide a value here your factory gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  ///
  /// example:
  ///    getIt.registerFactoryParam<TestClassParam,String,int>((s,i)
  ///        => TestClassParam(param1:s, param2: i));
  ///
  /// if you only use one parameter:
  ///
  ///    getIt.registerFactoryParam<TestClassParam,String,void>((s,_)
  ///        => TestClassParam(param1:s);
  static void registerFactoryParam<T extends Object, P1, P2>(
    FactoryFuncParam<T, P1, P2> factoryfunc, {
    String? instanceName,
  }) {
    _getIt.registerFactoryParam<T, P1, P2>(factoryfunc,
        instanceName: instanceName);
  }

  /// registers a type so that a new instance will be created on each call of [getAsync] on that type
  /// the creation function is executed asynchronously and has to be accessed  with [getAsync]
  /// [T] type to register
  /// [factoryfunc] async factory function for this type
  /// [instanceName] if you provide a value here your factory gets registered with that
  /// name instead of a type. This should only be necessary if you need to register more
  /// than one instance of one type. Its highly not recommended
  static void registerFactoryAsync<T extends Object>(
    FactoryFuncAsync<T> factoryfunc, {
    String? instanceName,
  }) {
    _getIt.registerFactoryAsync<T>(factoryfunc, instanceName: instanceName);
  }

  /// retrieves or creates an instance of a registered type [T] depending on the registration
  /// function used for this type or based on a name.
  /// for factories you can pass up to 2 parameters [param1,param2] they have to match the types
  /// given at registration with [registerFactoryParam()]
  static T get<T extends Object>({
    String? instanceName,
    dynamic param1,
    dynamic param2,
  }) {
    return _getIt.get<T>(
        instanceName: instanceName, param1: param1, param2: param2);
  }

  /// Returns an Future of an instance that is created by an async factory or a Singleton that is
  /// not ready with its initialization.
  /// for async factories you can pass up to 2 parameters [param1,param2] they have to match the types
  /// given at registration with [registerFactoryParamAsync()]
  static Future<T> getAsync<T extends Object>({
    String? instanceName,
    dynamic param1,
    dynamic param2,
  }) {
    return _getIt.getAsync<T>(
        instanceName: instanceName, param1: param1, param2: param2);
  }

  /// Unregister an [instance] of an object or a factory/singleton by Type [T] or by name [instanceName]
  /// if you need to dispose any resources you can do it using [disposingFunction] function
  /// that provides a instance of your class to be disposed. This function overrides the disposing
  /// you might have provided when registering.
  static void unregister<T extends Object>({
    Object? instance,
    String? instanceName,
    void Function(T)? disposingFunction,
  }) {
    _getIt.unregister<T>(
      instance: instance,
      instanceName: instanceName,
      disposingFunction: disposingFunction,
    );
  }

  /// returns a Future that completes if all asynchronously created Singletons and any Singleton that had
  ///  [signalsReady==true] are ready.
  /// This can be used inside a FutureBuilder to change the UI as soon as all initialization
  /// is done
  /// If you pass a [timeout], an [WaitingTimeOutException] will be thrown if not all Singletons
  /// were ready in the given time. The Exception contains details on which Singletons are not ready yet.
  /// if [allReady] should not wait for the completion of async Signletons set
  /// [ignorePendingAsyncCreation==true]
  static Future<void> allReady({
    Duration? timeout,
    bool ignorePendingAsyncCreation = false,
  }) {
    return _getIt.allReady(
        timeout: timeout,
        ignorePendingAsyncCreation: ignorePendingAsyncCreation);
  }
}
