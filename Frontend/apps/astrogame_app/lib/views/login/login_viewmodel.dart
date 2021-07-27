import 'package:astrogame_app/executers/login_executer.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class LoginViewModel extends BaseViewModel {
  LoginExecuter _loginExecuter;
  NavigationWrapper _navigationService;

  late TextEditingController emailController;
  late TextEditingController passwordController;

  LoginViewModel(
    this._loginExecuter,
    this._navigationService,
    @factoryParam String? lastEmail,
  ) {
    emailController = new TextEditingController(text: lastEmail);
    passwordController = new TextEditingController(text: 'Test1234!');
  }

  bool _stayLoggedIn = false;
  bool get stayLoggedIn => _stayLoggedIn;
  set stayLoggedIn(bool val) {
    _stayLoggedIn = val;
    notifyListeners();
  }

  Future loginAsync() async {
    var status = await _loginExecuter.loginAsync(
      emailController.text,
      passwordController.text,
      stayLoggedIn,
    );

    print(status);
  }

  void showRegisterView() {
    _navigationService.navigateTo(RoutePaths.RegisterRoute);
  }
}
