import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/views/home/widgets/construction_viewmodel.dart';
import 'package:duration/duration.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ConstructionView extends StatelessWidget {
  final BuildingConstruction _construction;

  ConstructionView(this._construction);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ConstructionViewModel>.reactive(
      builder: (context, model, _) => Container(
        child: Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            EnhancedFutureBuilder(
              future: model.getCurrentStellarObjectImageAsync(),
              rememberFutureResult: true,
              whenDone: (ImageProvider imageProvider) => Image(
                image: imageProvider,
                height: 100,
              ),
              whenNotDone: Container(),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(model.stellarObject.name),
                Text(model.stellarObject.coordinates.toString()),
                Text(
                  prettyDuration(
                      model.buildingConstruction!.startTime
                          .difference(DateTime.now()),
                      abbreviated: true,
                      delimiter: ' : '),
                ),
              ],
            ),
          ],
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(
        param1: _construction,
      ),
    );
  }
}
