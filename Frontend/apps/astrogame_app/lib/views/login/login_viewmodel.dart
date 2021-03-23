import 'package:astrogame_app/executers/login_executer.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class LoginViewModel extends BaseViewModel {
  LoginExecuter _loginExecuter;

  TextEditingController emailController;
  TextEditingController passwordController;

  LoginViewModel(
    this._loginExecuter,
  ) {
    emailController = new TextEditingController();
    passwordController = new TextEditingController();
  }

  Future loginAsync() async {
    var status = await _loginExecuter.loginAsync(
      emailController.text,
      passwordController.text,
    );

    print(status);
  }
}
