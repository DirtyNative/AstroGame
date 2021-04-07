import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:duration/duration.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

import 'constructions_viewmodel.dart';

class ConstructionsView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(32),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(16),
        color: AstroGameColors.lightGrey,
      ),
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.only(top: 16, bottom: 8),
            child: Text('Constructions in progress',
                style: Theme.of(context).textTheme.headline2),
          ),
          ViewModelBuilder<ConstructionsViewModel>.reactive(
            builder: (context, model, _) =>
                EnhancedFutureBuilder<BuildingChain>(
              future: model.fetchBuildingChain(),
              rememberFutureResult: true,
              whenDone: (buildingChain) => ListView.separated(
                shrinkWrap: true,
                itemBuilder: (context, index) => _constructionWidget(
                    context, model, buildingChain.buildingUpgrades[index]),
                separatorBuilder: (context, index) => SizedBox(height: 8),
                itemCount: buildingChain.buildingUpgrades.length ?? 0,
              ),
              whenNotDone: Container(),
            ),
            viewModelBuilder: () => ServiceLocator.get(),
          ),
        ],
      ),
    );
  }

  Widget _constructionWidget(BuildContext context, ConstructionsViewModel model,
      BuildingConstruction construction) {
    return Container(
      child: EnhancedFutureBuilder(
        future: Future.wait([
          model.getStellarObjectImageAsync(construction.stellarObjectId),
          model.fetchStellarObject(construction.stellarObjectId),
        ]),
        rememberFutureResult: true,
        whenDone: (data) => Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Image(
              image: data[0],
              height: 100,
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(data[1].name),
                Text(data[1].coordinates.toString()),
                Text(
                  prettyDuration(
                      construction.startTime.difference(DateTime.now()),
                      abbreviated: true,
                      delimiter: ' : '),
                ),
              ],
            ),
          ],
        ),
        whenNotDone: Container(),
      ),
    );
  }
}
