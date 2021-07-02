import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/researches/one_time_research.dart';
import 'package:astrogame_app/models/researches/research.dart';
import 'package:astrogame_app/models/researches/studied_research.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:stacked/stacked.dart';

import 'research_detail_viewmodel.dart';
import 'widgets/resource_view.dart';

class ResearchDetailView extends StatelessWidget {
  final Research _research;
  final StudiedResearch _studiedResearch;

  ResearchDetailView(this._research, this._studiedResearch);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResearchDetailViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          margin: EdgeInsets.only(left: 32, right: 32),
          child: ListView(
            children: [
              _headerWidget(context, model),
              (model.research is LevelableResearch)
                  ? _dynamicResearchCostsWidget(context, model)
                  : _oneTimeResearchCostsWidget(context, model),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(
        param1: _research,
        param2: _studiedResearch,
      ),
    );
  }

  Widget _headerWidget(BuildContext context, ResearchDetailViewModel model) {
    if (model.researchImage == null) {
      return Container();
    }

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
                    Text(model.research.name,
                        style: Theme.of(context).textTheme.headline1),
                    _levelText(context, model),
                    Text(model.research.description),
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
      return Text('Level ${model.studiedResearch?.level ?? 0}',
          style: Theme.of(context).textTheme.headline2);
    } else if (model.research is OneTimeResearch) {
      return SizedBox.shrink();
    }

    throw Exception(
        'Research ${model.research.runtimeType} is not implemented yet');
  }

  Widget _oneTimeResearchCostsWidget(
      BuildContext context, ResearchDetailViewModel model) {
    if (model.researchValues == null ||
        model.researchValues.length == 0 ||
        model.resources == null ||
        model.resources.length == 0) {
      return SizedBox.shrink();
    }

    return Container(
      //height: 512,
      margin: EdgeInsets.only(bottom: 32),
      child: Column(
        children: [
          Container(
            padding: EdgeInsets.all(16),
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(24),
              color: AstroGameColors.lightGrey,
            ),
            child: Center(
              child: Text(
                'Research costs',
                style: Theme.of(context).textTheme.headline2,
              ),
            ),
          ),
          SizedBox(height: 16),
          GridView.builder(
            shrinkWrap: true,
            itemCount: model.research.researchCosts.length,
            itemBuilder: (context, index) {
              var researchCost = model.research.researchCosts[index];
              var resource = model.resources.firstWhere(
                  (element) => element.id == researchCost.resourceId);

              return ResourceView(resource, researchCost);
            },
            gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(
                maxCrossAxisExtent: 300,
                childAspectRatio: 3 / 1,
                crossAxisSpacing: 20,
                mainAxisSpacing: 20),
          ),
        ],
      ),
    );
  }

  Widget _dynamicResearchCostsWidget(
      BuildContext context, ResearchDetailViewModel model) {
    if (model.researchValues == null ||
        model.researchValues.length == 0 ||
        model.resources == null ||
        model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources =
        calculateUsedResources(model, model.researchValues.first.researchCosts);
    double minValue = 0;
    double maxValue = calculateMax(model.researchValues.last.researchCosts);

    var step = (maxValue - minValue) / 10;

    return Container(
      height: 512,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(24),
        color: AstroGameColors.lightGrey,
      ),
      padding: EdgeInsets.all(32),
      margin: EdgeInsets.only(bottom: 32),
      child: Column(
        children: [
          Center(
            child: Text(
              'Research costs',
              style: Theme.of(context).textTheme.headline2,
            ),
          ),
          SizedBox(height: 32),
          Expanded(
            child: LineChart(
              new LineChartData(
                borderData: getBorderData(),
                axisTitleData: getAxisTitleData(context, 'Costs'),
                titlesData: getTitlesData(context, step),
                gridData: getGridData(step),
                lineTouchData: getLineTouchData(context, usedResources),
                lineBarsData: List.generate(
                  usedResources.length,
                  (index) => _generateResearchCostChartData(
                      model, usedResources[index].id, index),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  double calculateMax(List<ResourceAmount> amounts) {
    var maxValue = 0.0;

    amounts.forEach((element) {
      if (maxValue < element.amount) {
        maxValue = element.amount;
      }
    });

    return maxValue;
  }

  List<Resource> calculateUsedResources(
      ResearchDetailViewModel model, List<ResourceAmount> amounts) {
    List<Resource> usedResources = [];

    amounts.forEach((element) {
      usedResources.add(model.resources
          .firstWhere((resource) => resource.id == element.resourceId));
    });

    return usedResources;
  }

  LineChartBarData _generateResearchCostChartData(
      ResearchDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.researchValues.forEach((element) {
      var costs = element.researchCosts
          .firstWhere((costs) => costs.resourceId == resourceId);
      var spot = new FlSpot(
          element.level.toDouble(), costs.amount?.roundToDouble() ?? 0);
      spots.add(spot);
    });

    return getLineChartBarData(spots, index);
  }

  LineChartBarData getLineChartBarData(List<FlSpot> spots, int index) {
    return LineChartBarData(
      spots: spots,
      isCurved: true,
      colors: [
        getColor(index),
      ],
      belowBarData: BarAreaData(
        show: true,
        colors: [
          getColor(index).withOpacity(0.2),
        ],
      ),
    );
  }

  Color getColor(int index) {
    switch (index) {
      case 0:
        return AstroGameColors.purple;
      case 1:
        return AstroGameColors.torque;
      default:
        return Colors.red;
    }
  }

  LineTouchData getLineTouchData(
      BuildContext context, List<Resource> usedResources) {
    return LineTouchData(
      touchTooltipData: LineTouchTooltipData(
        tooltipBgColor: AstroGameColors.darkGrey,
        getTooltipItems: (touchedSpots) {
          return touchedSpots.map((e) {
            return LineTooltipItem(
              '${e.y.toInt()} ${usedResources[e.barIndex].name}',
              Theme.of(context).textTheme.bodyText1,
            );
          }).toList();
        },
      ),
    );
  }

  FlGridData getGridData(double step) {
    return FlGridData(
      horizontalInterval: (step == 0) ? 10 : step,
      drawVerticalLine: true,
    );
  }

  FlTitlesData getTitlesData(BuildContext context, double step) {
    return FlTitlesData(
      show: true,
      leftTitles: SideTitles(
        showTitles: true,
        interval: (step == 0) ? 1000 : step,
        getTextStyles: (value) => Theme.of(context).textTheme.bodyText1,
        margin: 30,
      ),
      bottomTitles: SideTitles(
        showTitles: true,
        getTextStyles: (value) => Theme.of(context).textTheme.bodyText1,
        margin: 20,
      ),
    );
  }

  FlAxisTitleData getAxisTitleData(BuildContext context, String leftTitle) {
    return FlAxisTitleData(
      show: true,
      leftTitle: AxisTitle(
        titleText: leftTitle,
        textStyle: Theme.of(context).textTheme.bodyText1,
        showTitle: true,
        margin: 32,
      ),
      bottomTitle: AxisTitle(
        margin: 0,
        showTitle: true,
        titleText: 'Level',
        textStyle: Theme.of(context).textTheme.bodyText1,
      ),
    );
  }

  FlBorderData getBorderData() {
    return FlBorderData(
      border: Border.all(
        color: Colors.white54,
        width: 1,
      ),
    );
  }
}
