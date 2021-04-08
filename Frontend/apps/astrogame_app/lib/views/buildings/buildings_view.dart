import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/views/buildings/buildings_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
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
            child: ListView.separated(
              itemCount: model.buildings?.length ?? 0,
              itemBuilder: (context, index) =>
                  BuildingView(model.buildings[index]),
              separatorBuilder: (context, index) => SizedBox(height: 16),
            ),
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }
}
