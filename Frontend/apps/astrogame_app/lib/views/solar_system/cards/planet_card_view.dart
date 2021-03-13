import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/views/solar_system/cards/planet_card_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:stacked/stacked.dart';

class PlanetCardView extends StatelessWidget {
  final Planet _planet;

  PlanetCardView(this._planet);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<PlanetCardViewModel>.reactive(
      builder: (context, model, _) => Container(
        height: 70,
        width: 300,
        child: Row(
          children: [
            SvgPicture.asset(
              'assets/images/planet.svg',
              color: Colors.white,
              semanticsLabel: 'A red up arrow',
              height: 50,
            ),
            SizedBox(width: 16),
            Text(model.planet.name),
            SizedBox(width: 16),
            Text('Any other info')
          ],
        ),
      ),
      viewModelBuilder: () => PlanetCardViewModel(_planet),
    );
  }
}
