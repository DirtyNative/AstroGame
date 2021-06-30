import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/views/galaxy/galaxy_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class GalaxyView extends StatelessWidget {
  static const double size = 1000;

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<GalaxyViewModel>.reactive(
      builder: (context, model, _) => InteractiveViewer(
        onInteractionUpdate: (details) {
          print(details.focalPoint);
        },
        minScale: 10,
        maxScale: 1000,
        child: _generateGalaxyMap(model.solarSystems),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _generateGalaxyMap(List<SolarSystem> solarSystems) {
    return Stack(
      children: _generateSolarSystem(solarSystems),
    );
  }

  List<Widget> _generateSolarSystem(List<SolarSystem> solarSystems) {
    List<Widget> widgets = [];

    for (int i = 0; i < solarSystems.length; i++) {
      var solarSystem = Positioned(
        left: solarSystems[i].position.x * size,
        top: solarSystems[i].position.z * size,
        child: Container(
          color: Colors.white,
          height: 0.05,
          width: 0.05,
        ),
      );

      widgets.add(solarSystem);
    }

    return widgets;
  }
}
