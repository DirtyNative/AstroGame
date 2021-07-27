import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/views/common/technology_cost_view.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

import 'research_detail_viewmodel.dart';

class ResearchDetailView extends StatelessWidget {
  final Research _research;
  final FinishedTechnology? _finishedTechnology;

  ResearchDetailView(this._research, this._finishedTechnology);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResearchDetailViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          margin: EdgeInsets.only(left: 32, right: 32),
          child: ListView(
            children: [
              _headerWidget(context, model),
              TechnologyCostView(_research, _finishedTechnology),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(
        param1: _research,
        param2: _finishedTechnology,
      ),
    );
  }

  Widget _headerWidget(BuildContext context, ResearchDetailViewModel model) {
    return Container(
      padding: EdgeInsets.only(top: 32, bottom: 32),
      height: 500,
      child: Stack(
        children: [
          Positioned(
            left: 0,
            right: 0,
            bottom: 0,
            top: 0,
            child: ClipRRect(
              borderRadius: BorderRadius.all(Radius.circular(32)),
              child: Image(
                image: model.researchImage,
                fit: BoxFit.cover,
              ),
            ),
          ),
          Positioned(
            left: 0,
            right: 0,
            top: 0,
            child: Container(
              decoration: BoxDecoration(
                  color: Colors.black26,
                  borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(32),
                    topRight: Radius.circular(32),
                  )),
              child: Padding(
                padding: const EdgeInsets.all(32.0),
                child: Column(
                  children: [
                    Text(model.research!.name,
                        style: Theme.of(context).textTheme.headline1),
                    _levelText(context, model),
                    Text(model.research!.description),
                    ElevatedButton(
                      onPressed: model.showTechTreeView,
                      child: Text('Tech tree'),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _levelText(BuildContext context, ResearchDetailViewModel model) {
    if (model.research is LevelableResearch) {
      return Text('Level ${model.finishedTechnology?.level ?? 0}',
          style: Theme.of(context).textTheme.headline2);
    } else if (model.research is OneTimeResearch) {
      return SizedBox.shrink();
    }

    throw Exception(
        'Research ${model.research.runtimeType} is not implemented yet');
  }
}
