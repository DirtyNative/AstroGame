import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/views/buildings/buildings_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

import 'widgets/building_view.dart';

class BuildingsView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingsViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          padding: EdgeInsets.all(32),
          child: Scrollbar(
            child: EnhancedFutureBuilder(
              future: model.buildingsProvider.get(),
              rememberFutureResult: true,
              whenDone: (buildings) =>
                  EnhancedFutureBuilder<BuildingConstruction>(
                future: model.fetchActiveConstruction(),
                rememberFutureResult: true,
                whenDone: (construction) => ListView.separated(
                  itemCount: buildings.length,
                  itemBuilder: (context, index) =>
                      BuildingView(buildings[index], construction),
                  separatorBuilder: (context, index) => SizedBox(height: 16),
                ),
                whenNotDone: Container(),
              ),
              whenNotDone: SizedBox.shrink(),
            ),
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
