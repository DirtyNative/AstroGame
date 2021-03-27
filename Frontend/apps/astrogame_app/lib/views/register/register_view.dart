import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/register/register_viewmodel.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:astrogame_app/widgets/glass_container.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class RegisterView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<RegisterViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: GestureDetector(
          child: Container(
            decoration: BoxDecoration(
              color: AstroGameColors.mediumGrey,
              image: DecorationImage(
                  image: AssetImage('assets/images/background_2.png'),
                  fit: BoxFit.cover),
            ),
            child: Stack(
              children: [
                _desktopView(context, model),
                AnimatedOpacity(
                  duration: Duration(milliseconds: 300),
                  opacity: model.isBusy ? 1 : 0,
                  child: (model.isBusy)
                      ? _loadingOverlay(context)
                      : SizedBox.shrink(),
                ),
              ],
            ),
          ),
          onTap: () => FocusScope.of(context).unfocus(),
          behavior: HitTestBehavior.opaque,
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _desktopView(BuildContext context, RegisterViewModel model) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        AppHeader(),
        _desktopLoginBox(context, model),
        _footer(),
      ],
    );
  }

  Widget _desktopLoginBox(BuildContext context, RegisterViewModel model) {
    return Container(
      width: 500,
      child: GlassContainer(
        child: Column(
          children: [
            Text(
              'Register',
              style: Theme.of(context).textTheme.headline1,
            ),

            // Email
            SizedBox(height: 48),
            TextField(
              controller: model.emailController,
              decoration: InputDecoration(hintText: 'Email'),
              keyboardType: TextInputType.emailAddress,
            ),

            // Username
            SizedBox(height: 16),
            TextField(
              controller: model.usernameController,
              decoration: InputDecoration(hintText: 'Username'),
            ),

            // Password
            SizedBox(height: 16),
            TextField(
              controller: model.passwordController,
              decoration: InputDecoration(hintText: 'Password'),
              obscureText: true,
            ),

            // Password confirmation
            SizedBox(height: 16),
            TextField(
              controller: model.passwordConfirmationController,
              decoration: InputDecoration(hintText: 'Password confirmation'),
              obscureText: true,
            ),

            SizedBox(height: 48),
            ElevatedButton(
              onPressed: model.registerAsync,
              child: Text('Register'),
            ),
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
}
