import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:flutter/material.dart';

class PlanetCardView extends StatelessWidget {
  final Planet _planet;
  final Function _onTap;

  PlanetCardView(this._planet, this._onTap);

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () => _onTap(),
      child: Container(
        height: 70,
        child: Row(
          children: [
            (_planet.colonizedStellarObject == null)
                ? SizedBox.shrink()
                : Text('colonized'),
            ImageIcon(
              (_planet.hasHabitableAtmosphere)
                  ? AssetImage('assets/images/planet_atmosphere@64px.png')
                  : AssetImage('assets/images/planet@64px.png'),
              color: Colors.white,
              size: 50,
            ),
            SizedBox(width: 16),
            Text(_planet.name),
            SizedBox(width: 16),
            Text(_planet.coordinates.toString()),
          ],
        ),
      ),
    );
  }
}
