import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/views/solar_system/solar_system_view.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:stacked/stacked.dart';
import 'start_viewmodel.dart';

class StartView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<StartViewModel>.reactive(
      builder: (context, model, _) => Scaffold(
        body: Container(
          decoration: BoxDecoration(
            image: DecorationImage(
                image: AssetImage('assets/images/background_2.png'),
                fit: BoxFit.cover),
          ),
          child: Container(
            child: Column(
              children: [
                Row(
                  children: [
                    Container(
                      //height: 50,
                      width: 200,
                      child: TextFormField(
                        controller: model.solarSystemNumberController,
                        inputFormatters: [
                          FilteringTextInputFormatter.digitsOnly
                        ],
                      ),
                    ),
                    ElevatedButton(
                      onPressed: model.loadSolarSystemAsync,
                      child: Text('Load Solar System 20'),
                    ),
                  ],
                ),
                Expanded(
                  child: InteractiveViewer(
                    constrained: false,
                    maxScale: 1,
                    minScale: 1,
                    child: SolarSystemView(),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
      viewModelBuilder: () => getIt.get(),
    );
  }
}
