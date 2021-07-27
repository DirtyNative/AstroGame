import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/colony_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ColonyView extends StatelessWidget {
  final ColonizedStellarObject _colonizedStellarObject;

  final LinearGradient _selectedGradient = LinearGradient(colors: [
    AstroGameColors.purple,
    AstroGameColors.torque,
  ]);

  final LinearGradient _notSelectedGradient = LinearGradient(colors: [
    AstroGameColors.lightGrey,
    AstroGameColors.lightGrey,
  ]);

  ColonyView(this._colonizedStellarObject);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ColonyViewModel>.reactive(
      builder: (context, model, _) => model.isBusy
          ? SizedBox.shrink()
          : Padding(
              padding: const EdgeInsets.only(left: 8, bottom: 8),
              child: Container(
                padding: EdgeInsets.only(bottom: 16),
                decoration: BoxDecoration(
                  gradient: (model.isSelected)
                      ? _selectedGradient
                      : _notSelectedGradient,
                  borderRadius: BorderRadius.only(
                    bottomLeft: Radius.circular(16),
                    topLeft: Radius.circular(16),
                  ),
                ),
                child: Column(
                  children: [
                    Image(
                      image: model.stellarObjectImage,
                      height: 100,
                    ),
                    Text(model.stellarObject?.name ?? ''),
                    Text(model.stellarObject?.coordinates.toString() ?? ''),
                  ],
                ),
              ),
            ),
      viewModelBuilder: () =>
          ServiceLocator.get(param1: _colonizedStellarObject),
    );
  }
}
