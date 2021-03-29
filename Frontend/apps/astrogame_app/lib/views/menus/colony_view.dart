import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/colony_viewmodel.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
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
          child: EnhancedFutureBuilder(
            future: Future.wait([
              model.getStellarObjectImageAsync(
                  model.colonizedStellarObject.stellarObjectId),
              model.fetchStellarObject(
                  model.colonizedStellarObject.stellarObjectId),
            ]),
            rememberFutureResult: true,
            whenDone: (data) => Column(
              children: [
                Image(
                  image: data[0],
                  height: 100,
                ),
                Text(data[1].name),
                Text(data[1].coordinates.toString()),
              ],
            ),
            whenNotDone: Container(),
          ),
        ),
      ),
      viewModelBuilder: () =>
          ServiceLocator.get(param1: _colonizedStellarObject),
    );
  }
}
