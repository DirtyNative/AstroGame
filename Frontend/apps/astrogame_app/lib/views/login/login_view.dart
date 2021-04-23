import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/login/login_viewmodel.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:astrogame_app/widgets/glass_container.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class LoginView extends StatelessWidget {
  final String _lastEmail;

  LoginView(this._lastEmail);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<LoginViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: GestureDetector(
          child: Container(
            decoration: BoxDecoration(
              color: AstroGameColors.mediumGrey,
              image: DecorationImage(image: AssetImage('assets/images/background_2.png'), fit: BoxFit.cover),
            ),
            child: Stack(
              children: [
                _desktopView(context, model),
                AnimatedOpacity(
                  duration: Duration(milliseconds: 300),
                  opacity: model.isBusy ? 1 : 0,
                  child: (model.isBusy) ? _loadingOverlay(context) : SizedBox.shrink(),
                ),
              ],
            ),
          ),
          onTap: () => FocusScope.of(context).unfocus(),
          behavior: HitTestBehavior.opaque,
        ),
      ),
      viewModelBuilder: () => getIt.get(param1: _lastEmail),
    );
  }

  Widget _desktopView(BuildContext context, LoginViewModel model) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        AppHeader(),
        _desktopLoginBox(context, model),
        _footer(),
      ],
    );
  }

  Widget _desktopLoginBox(BuildContext context, LoginViewModel model) {
    return Container(
      width: 500,
      child: GlassContainer(
        child: Column(
          children: [
            Text(
              'AstroGame',
              style: Theme.of(context).textTheme.headline1,
            ),
            SizedBox(height: 48),
            TextField(
              controller: model.emailController,
              decoration: InputDecoration(hintText: 'Email'),
              keyboardType: TextInputType.emailAddress,
            ),
            SizedBox(height: 16),
            TextField(
              controller: model.passwordController,
              decoration: InputDecoration(hintText: 'Password'),
              obscureText: true,
            ),

            SizedBox(height: 16),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Checkbox(value: model.stayLoggedIn, onChanged: (checked) => model.stayLoggedIn = checked),
                Text('Stay logged in'),
              ],
            ),

            SizedBox(height: 48),
            ElevatedButton(
              onPressed: model.loginAsync,
              child: Text('Login'),
            ),

            // Register
            SizedBox(height: 16),
            TextButton(
              onPressed: model.showRegisterView,
              child: Text('Register now'),
            ),
          ],
        ),
      ),
    );
  }

  Widget _footer() {
    return Container(
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 48, vertical: 16),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text('About'),
            SizedBox(width: 48),
            Text('Impressum'),
            SizedBox(width: 48),
            Text('Contact'),
          ],
        ),
      ),
    );
  }

  Widget _loadingOverlay(BuildContext context) {
    return Container(
      color: Colors.black38,
      width: MediaQuery.of(context).size.width,
      height: MediaQuery.of(context).size.height,
      child: Center(
        child: CircularProgressIndicator(),
      ),
    );
  }
}
