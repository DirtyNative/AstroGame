import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/views/home/home_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class HomeView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<HomeViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
