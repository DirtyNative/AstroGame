import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/moon.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:astrogame_app/models/stellar/systems/multi_object_system.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/views/solar_system/cards/moon_card_view.dart';
import 'package:astrogame_app/views/solar_system/cards/planet_card_view.dart';
import 'package:astrogame_app/views/solar_system/cards/star_card_view.dart';
import 'package:astrogame_app/views/solar_system/solar_system_viewmodel.dart';
import 'package:astrogame_app/widgets/glass_container.dart';
import 'package:astrogame_app/widgets/horizontal_line.dart';
import 'package:astrogame_app/widgets/vertical_line.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:stacked/stacked.dart';

class SolarSystemView extends StatelessWidget {
  SolarSystemView();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<SolarSystemViewModel>.reactive(
      builder: (context, model, _) =>
          generateSolarSystemWidget(model.solarSystem),
      viewModelBuilder: () => getIt.get(),
    );
  }

  Widget generateSolarSystemWidget(SolarSystem solarSystem) {
    if (solarSystem == null) {
      return SizedBox.shrink();
    }

    return Container(
      child: _generateSubWidget(solarSystem, true),
    );
  }

  Widget _generateSubWidget(StellarSystem stellarSystem, bool vertical) {
    if (stellarSystem == null) {
      return SizedBox.shrink();
    }

    if (stellarSystem.centerObjects == null ||
        stellarSystem.centerObjects.length < 1) {
      return SizedBox.shrink();
    }

    /*List<Widget> subSystemWidgets = List<Widget>.generate(
        multiObjectSystem.satellites.length,
        (index) =>
            _generateSubWidget(multiObjectSystem.satellites[index], !vertical)); */

    /*List<Widget> subSystemWidgets = List<Widget>.filled(
        multiObjectSystem.satellites.length,
        CustomPaint(
          painter: VerticalLinePainter(),
        ),
        growable: true);*/

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

      var widget = _generateSubWidget(stellarSystem.satellites[i], !vertical);
      subSystemWidgets.add(widget);
    }

    if (vertical) {
      return Row(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _stellarSystemWidget(stellarSystem),
          Container(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: subSystemWidgets,
            ),
          ),
        ],
      );
    } else {
      return Column(
        children: [
          _stellarSystemWidget(stellarSystem),
          Column(
            children: subSystemWidgets,
          ),
        ],
      );
    }
  }

  Widget _stellarSystemWidget(StellarSystem stellarSystem) {
    List<Widget> stellarObjects = List<Widget>.generate(
        stellarSystem.centerObjects.length,
        (index) => _stellarObjectWidget(stellarSystem.centerObjects[index]));

    return GlassContainer(
        padding: EdgeInsets.all(16),
        child: Row(
          children: [
            /*SvgPicture.asset(
              'assets/images/system.svg',
              color: Colors.white,
              semanticsLabel: 'A red up arrow',
              height: 25,
            ), */
            Column(
              children: stellarObjects,
            ),
          ],
        ));
  }

  Widget _stellarObjectWidget(StellarObject stellarObject) {
    if (stellarObject is Star) {
      return StarCardView(stellarObject);
    }

    if (stellarObject is Planet) {
      return new PlanetCardView(stellarObject);
    }

    if (stellarObject is Moon) {
      return MoonCardView(stellarObject);
    }

    return SizedBox.shrink();
  }
}
