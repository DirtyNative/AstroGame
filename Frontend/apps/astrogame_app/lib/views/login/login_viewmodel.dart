import 'package:astrogame_app/executers/login_executer.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:stacked_services/stacked_services.dart';

@injectable
class LoginViewModel extends BaseViewModel {
  LoginExecuter _loginExecuter;
  NavigationService _navigationService;

  TextEditingController emailController;
  TextEditingController passwordController;

  LoginViewModel(
    this._loginExecuter,
    this._navigationService,
  ) {
    emailController =
        new TextEditingController(text: 'daniel@dirtyandnative.de');
    passwordController = new TextEditingController(text: 'Test1234!');
  }

  Future loginAsync() async {
    var status = await _loginExecuter.loginAsync(
      emailController.text,
      passwordController.text,
    );

    print(status);
  }

  void showRegisterView() {
    _navigationService.navigateTo(RoutePaths.RegisterRoute);
  }
}
