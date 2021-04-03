import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/widgets/building_viewmodel.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class BuildingView extends StatelessWidget {
  final Building _building;

  BuildingView(this._building);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingViewModel>.reactive(
      builder: (context, model, _) => Container(
        height: 150,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(16),
          color: AstroGameColors.lightGrey,
        ),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // Image
            _buildingImageWidget(model),

            Expanded(
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(model.building.name,
                        style: Theme.of(context).textTheme.headline2),
                    Text(
                      model.building.description,
                    ),
                    Expanded(child: Container()),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        // Build button
                        ElevatedButton(
                          onPressed: (model.hasEnoughResourcesToBuild)
                              ? () => {}
                              : null,
                          child: Text((model.builtBuilding == null)
                              ? 'Build'
                              : 'Upgrade to level ${model.builtBuilding.level + 1}'),
                        ),
                      ],
                    )
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(param1: _building),
    );
  }

  Widget _buildingImageWidget(BuildingViewModel model) {
    return EnhancedFutureBuilder(
      future: model.getImageAsync(model.building.id),
      whenDone: (data) => ClipRRect(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(16),
          bottomLeft: Radius.circular(16),
          bottomRight: Radius.circular(32),
        ),
        child: Image(
          image: data,
          height: 150,
          fit: BoxFit.fitHeight,
        ),
      ),
      whenError: (error) => Container(),
      whenWaiting: CircularProgressIndicator(),
      whenNotDone: Container(),
      rememberFutureResult: true,
    );
  }
}
