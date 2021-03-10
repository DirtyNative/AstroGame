import 'package:astrogame_app/configurations/service_container.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';
import 'start_viewmodel.dart';

class StartView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<StartViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: Container(
          child: Column(
            children: [
              ElevatedButton(
                onPressed: model.loadSolarSystemAsync,
                child: Text('Load Solar System 20'),
              ),
              model.generateSolarSystemWidget(model.solarSystem),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => getIt.get(),
    );
  }
}
