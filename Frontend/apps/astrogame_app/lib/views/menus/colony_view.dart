import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/colony_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ColonyView extends StatelessWidget {
  final ColonizedStellarObject _colonizedStellarObject;

  ColonyView(this._colonizedStellarObject);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ColonyViewModel>.reactive(
      builder: (context, model, _) => Padding(
        padding: const EdgeInsets.only(left: 8, bottom: 8),
        child: Container(
          padding: EdgeInsets.only(bottom: 16),
          decoration: BoxDecoration(
            //color: AstroGameColors.lightGrey,
            gradient: (model.isSelected)
                ? LinearGradient(colors: [
                    AstroGameColors.purple,
                    AstroGameColors.torque,
                  ])
                : LinearGradient(
                    colors: [
                      AstroGameColors.lightGrey,
                      AstroGameColors.lightGrey,
                    ],
                  ),

            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(16),
              topLeft: Radius.circular(16),
            ),
          ),
          child: FutureBuilder(
              future: Future.wait([
                model.getStellarObjectImageAsync(
                    model.colonizedStellarObject.stellarObjectId),
                model.fetchStellarObject(
                    model.colonizedStellarObject.stellarObjectId),
              ]),
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  return Column(
                    children: [
                      Image(
                        image: snapshot.data[0],
                        height: 100,
                      ),
                      Text(snapshot.data[1].name),
                      Text(snapshot.data[1].coordinates.toString()),
                    ],
                  );
                } else {
                  return SizedBox.shrink();
                }
              }),
        ),
      ),
      viewModelBuilder: () =>
          ServiceLocator.get(param1: _colonizedStellarObject),
    );
  }
}
