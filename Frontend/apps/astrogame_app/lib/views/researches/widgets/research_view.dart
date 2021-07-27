import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/researches/widgets/research_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ResearchView extends StatelessWidget {
  final Research _research;

  ResearchView(this._research);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResearchViewModel>.reactive(
      builder: (context, model, _) => Container(
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
                        Text(model.research!.name,
                            style: Theme.of(context).textTheme.headline2),

                        // Show the level only if it's a levelable research
                        if (model.research is LevelableResearch)
                          Text('Level ${model.finishedTechnology?.level ?? 0}')
                        else if (model.research is OneTimeResearch)
                          SizedBox.shrink(),
                      ],
                    ),
                    Text(
                      model.research!.description,
                    ),
                    Expanded(child: Container()),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        TextButton(
                            onPressed: model.showResearchDetails,
                            child: Text('Details')),
                        ElevatedButton(
                          //onPressed: (model.isConstructable) ? model.buildAsync : null,
                          onPressed: () {},
                          child: Text(model.studyText),
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
      viewModelBuilder: () => ServiceLocator.get(param1: _research),
    );
  }

  Widget _buildingImageWidget(ResearchViewModel model) {
    return InkWell(
      // onTap: model.showBuildingDetails,
      child: ClipRRect(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(16),
          bottomLeft: Radius.circular(16),
          bottomRight: Radius.circular(32),
        ),
        child: (model.researchImage == null)
            ? Container()
            : Image(
                image: model.researchImage,
                height: 150,
                fit: BoxFit.fitHeight,
              ),
      ),
    );
  }
}
