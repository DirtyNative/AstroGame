import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/widgets/building_viewmodel.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class BuildingView extends StatelessWidget {
  final Building _building;
  final BuildingConstruction _buildingConstruction;

  BuildingView(this._building, this._buildingConstruction);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingViewModel>.reactive(
      builder: (context, model, _) => Container(
        height: 150,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(16),
          color: AstroGameColors.lightGrey,
        ),
        child: EnhancedFutureBuilder<BuiltBuilding>(
          future: model.getBuiltBuildingAsync(model.building.id),
          rememberFutureResult: true,
          whenDone: (builtBuilding) => Row(
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
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(model.building.name,
                              style: Theme.of(context).textTheme.headline2),
                          Text('Level ${builtBuilding?.level ?? 0}')
                        ],
                      ),
                      Text(
                        model.building.description,
                      ),
                      Expanded(child: Container()),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        children: [
                          ElevatedButton(
                            onPressed: (model.isConstructable(builtBuilding))
                                ? model.buildAsync
                                : null,
                            child:
                                Text(model.getconstructionText(builtBuilding)),
                          ),
                        ],
                      )
                    ],
                  ),
                ),
              ),
            ],
          ),
          whenNotDone: Center(child: CircularProgressIndicator()),
        ),
      ),
      viewModelBuilder: () =>
          ServiceLocator.get(param1: _building, param2: _buildingConstruction),
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
