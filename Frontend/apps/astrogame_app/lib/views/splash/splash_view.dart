import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/splash/splash_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class SplashView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<SplashViewModel>.reactive(
        builder: (context, model, _) => Container(
              color: AstroGameColors.mediumGrey,
              child: Center(
                child: CircularProgressIndicator(),
              ),
            ),
        viewModelBuilder: () => ServiceLocator.get());
  }
}
