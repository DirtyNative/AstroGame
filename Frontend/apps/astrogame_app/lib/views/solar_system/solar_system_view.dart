import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/black_hole.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/moon.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/views/solar_system/cards/black_hole_card_view.dart';
import 'package:astrogame_app/views/solar_system/cards/moon_card_view.dart';
import 'package:astrogame_app/views/solar_system/cards/planet_card_view.dart';
import 'package:astrogame_app/views/solar_system/cards/star_card_view.dart';
import 'package:astrogame_app/views/solar_system/solar_system_viewmodel.dart';
import 'package:astrogame_app/widgets/glass_container.dart';
import 'package:astrogame_app/widgets/horizontal_line.dart';
import 'package:astrogame_app/widgets/vertical_line.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class SolarSystemView extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<SolarSystemView> {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<SolarSystemViewModel>.reactive(
      createNewModelOnInsert: true,
      builder: (context, model, _) => Padding(
        padding: const EdgeInsets.all(16.0),
        child: generateSolarSystemWidget(model, model.solarSystem),
      ),
      viewModelBuilder: () => getIt.get(),
    );
  }

  Widget generateSolarSystemWidget(
      SolarSystemViewModel model, SolarSystem solarSystem) {
    if (solarSystem == null) {
      return SizedBox.shrink();
    }

    return Container(
      child: _generateSubWidget(model, solarSystem, true),
    );
  }

  Widget _generateSubWidget(
      SolarSystemViewModel model, StellarSystem stellarSystem, bool vertical) {
    if (stellarSystem == null) {
      return SizedBox.shrink();
    }

    if (stellarSystem.centerObjects == null ||
        stellarSystem.centerObjects.length < 1) {
      return SizedBox.shrink();
    }

    List<Widget> subSystemWidgets = <Widget>[];

    for (int i = 0; i < stellarSystem.satellites.length; i++) {
      if (vertical) {
        subSystemWidgets.add(
          CustomPaint(
            size: Size(50, 100),
            painter: HorizontalLinePainter(),
          ),
        );
      } else {
        subSystemWidgets.add(
          CustomPaint(
            size: Size(100, 50),
            painter: VerticalLinePainter(),
          ),
        );
      }

      var widget =
          _generateSubWidget(model, stellarSystem.satellites[i], !vertical);
      subSystemWidgets.add(widget);
    }

    if (vertical) {
      return Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _stellarSystemWidget(model, stellarSystem),
          Container(
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: subSystemWidgets,
            ),
          ),
        ],
      );
    } else {
      return Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _stellarSystemWidget(model, stellarSystem),
          Column(
            children: subSystemWidgets,
          ),
        ],
      );
    }
  }

  Widget _stellarSystemWidget(
      SolarSystemViewModel model, StellarSystem stellarSystem) {
    List<Widget> stellarObjects = List<Widget>.generate(
        stellarSystem.centerObjects.length,
        (index) =>
            _stellarObjectWidget(model, stellarSystem.centerObjects[index]));

    return GlassContainer(
        padding: EdgeInsets.all(16),
        width: 400,
        child: Row(
          children: [
            Column(
              children: stellarObjects,
            ),
          ],
        ));
  }

  Widget _stellarObjectWidget(
      SolarSystemViewModel model, StellarObject stellarObject) {
    if (stellarObject is Star) {
      return StarCardView(stellarObject);
    }

    if (stellarObject is Planet) {
      return new PlanetCardView(
          stellarObject, () => model.showPlanetView(stellarObject));
    }

    if (stellarObject is Moon) {
      return MoonCardView(stellarObject);
    }

    if (stellarObject is BlackHole) {
      return BlackHoleCardView(stellarObject);
    }

    throw new Exception('Type ${stellarObject.runtimeType} not found');
  }
}
