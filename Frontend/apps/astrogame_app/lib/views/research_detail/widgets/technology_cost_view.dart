import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/researches/levelable_research.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:stacked/stacked.dart';

import 'resource_view.dart';
import 'technology_cost_viewmodel.dart';

class TechnologyCostView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<TechnologyCostViewModel>.reactive(
      builder: (context, model, _) => (model.research is LevelableResearch)
          ? _dynamicResearchCostsWidget(context, model)
          : _oneTimeResearchCostsWidget(context, model),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _oneTimeResearchCostsWidget(
      BuildContext context, TechnologyCostViewModel model) {
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
            itemCount: model.research.technologyCosts.length,
            itemBuilder: (context, index) {
              var researchCost = model.research.technologyCosts[index];
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
      BuildContext context, TechnologyCostViewModel model) {
    if (model.researchValues == null ||
        model.researchValues.length == 0 ||
        model.resources == null ||
        model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(
        model, model.researchValues.first.technologyCosts);
    double minValue = 0;
    double maxValue = calculateMax(model.researchValues.last.technologyCosts);

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
      TechnologyCostViewModel model, List<ResourceAmount> amounts) {
    List<Resource> usedResources = [];

    amounts.forEach((element) {
      usedResources.add(model.resources
          .firstWhere((resource) => resource.id == element.resourceId));
    });

    return usedResources;
  }

  LineChartBarData _generateResearchCostChartData(
      TechnologyCostViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.researchValues.forEach((element) {
      var costs = element.technologyCosts
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
