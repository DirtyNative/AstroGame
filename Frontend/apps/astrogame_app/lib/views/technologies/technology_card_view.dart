import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/technologies/levelable_technology.dart';
import 'package:astrogame_app/models/technologies/one_time_technology.dart';
import 'package:astrogame_app/models/technologies/technology.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/technologies/technology_card_placeholder_view.dart';
import 'package:astrogame_app/views/technologies/technology_card_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class TechnologyCardView extends StatelessWidget {
  final Technology _technology;

  TechnologyCardView(this._technology);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<TechnologyCardViewModel>.reactive(
      builder: (context, model, _) => model.isBusy
          ? TechnologyCardPlaceholderView()
          : Container(
              margin: EdgeInsets.only(bottom: 16),
              height: 150,
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(16),
                color: AstroGameColors.lightGrey,
              ),
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  // Image
                  _imageWidget(model),

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
                              Text(model.technology!.name,
                                  style: Theme.of(context).textTheme.headline2),

                              // Show the level only if it's a levelable building
                              if (model.technology is LevelableTechnology)
                                Text(
                                    'Level ${model.finishedTechnology?.level ?? 0}')
                              else if (model.technology is OneTimeTechnology)
                                SizedBox.shrink(),
                            ],
                          ),
                          Text(
                            model.technology!.description,
                          ),
                          Expanded(child: Container()),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              TextButton(
                                  onPressed: model.showDetails,
                                  child: Text('Details')),
                              ElevatedButton(
                                onPressed: (model.isConstructable)
                                    ? model.buildAsync
                                    : null,
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
      viewModelBuilder: () => ServiceLocator.get(param1: _technology),
    );
  }

  Widget _imageWidget(TechnologyCardViewModel model) {
    return InkWell(
      onTap: model.showDetails,
      child: ClipRRect(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(16),
          bottomLeft: Radius.circular(16),
          bottomRight: Radius.circular(32),
        ),
        child: Image(
          image: model.buildingImage,
          height: 150,
          fit: BoxFit.fitHeight,
        ),
      ),
    );
  }
}
