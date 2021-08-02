import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_technology_upgrade.dart';
import 'package:astrogame_app/views/home/widgets/construction_placeholder_view.dart';
import 'package:astrogame_app/views/home/widgets/construction_viewmodel.dart';
import 'package:duration/duration.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ConstructionView extends StatelessWidget {
  final StellarObjectDependentTechnologyUpgrade _construction;

  ConstructionView(this._construction);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ConstructionViewModel>.reactive(
      builder: (context, model, _) => (model.isBusy)
          ? ConstructionPlaceholderView()
          : Container(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  Image(
                    image: model.stellarObjectImage,
                    height: 100,
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
