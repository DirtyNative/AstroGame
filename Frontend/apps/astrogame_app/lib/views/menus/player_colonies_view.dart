import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/colony_view.dart';
import 'package:astrogame_app/views/menus/player_colonies_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class PlayerColoniesView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<PlayerColoniesViewModel>.reactive(
      builder: (context, model, _) => Material(
        child: Container(
          color: AstroGameColors.mediumGrey,
          child: Scrollbar(
            child: ListView.builder(
              itemCount: model.colonies.length,
              itemBuilder: (context, index) =>
                  ColonyView(model.colonies[index]),
            ),
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
