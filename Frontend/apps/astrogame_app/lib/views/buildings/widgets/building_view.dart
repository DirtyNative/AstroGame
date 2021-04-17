import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/buildings/widgets/building_viewmodel.dart';
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
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [Text(model.building.name, style: Theme.of(context).textTheme.headline2), Text('Level ${model.builtBuilding?.level ?? 0}')],
                    ),
                    Text(
                      model.building.description,
                    ),
                    Expanded(child: Container()),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        ElevatedButton(
                          onPressed: (model.isConstructable) ? model.buildAsync : null,
                          child: Text(model.constructionText),
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
    return InkWell(
      onTap: model.showBuildingDetails,
      child: ClipRRect(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(16),
          bottomLeft: Radius.circular(16),
          bottomRight: Radius.circular(32),
        ),
        child: (model.buildingImage == null)
            ? Container()
            : Image(
                image: model.buildingImage,
                height: 150,
                fit: BoxFit.fitHeight,
              ),
      ),
    );
  }
}
