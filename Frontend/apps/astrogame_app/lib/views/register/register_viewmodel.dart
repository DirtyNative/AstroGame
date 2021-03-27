import 'package:flutter/cupertino.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class RegisterViewModel extends BaseViewModel {
  TextEditingController emailController;
  TextEditingController usernameController;
  TextEditingController passwordController;
  TextEditingController passwordConfirmationController;

  bool get isRegisterButtonEnabled =>
      isValidEmail && isUsernameValid && isPasswordValid && arePasswordsEqual;

  bool get isValidEmail =>
      emailController.text != '' &&
      emailController.text.contains('@') &&
      emailController.text.contains('.');

  bool get isUsernameValid => usernameController.text != '';

  bool get isPasswordValid => passwordController.text.length >= 8;

  bool get arePasswordsEqual =>
      passwordController.text == passwordConfirmationController.text;

  Future registerAsync() async {}
}
