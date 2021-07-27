import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_value.dart';
import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/buildings/levelable_building.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/building_detail/building_detail_viewmodel.dart';
import 'package:astrogame_app/views/common/technology_cost_view.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

import 'package:stacked/stacked.dart';

class BuildingDetailView extends StatelessWidget {
  final Building _building;
  final FinishedTechnology? _finishedTechnology;

  BuildingDetailView(this._building, this._finishedTechnology);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingDetailViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          margin: EdgeInsets.only(left: 32, right: 32),
          child: ListView(
            children: [
              _headerWidget(context, model),
              TechnologyCostView(_building, _finishedTechnology),
              _productionWidget(context, model),
              _consumptionWidget(context, model),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(
        param1: _building,
        param2: _finishedTechnology,
      ),
    );
  }

  Widget _headerWidget(BuildContext context, BuildingDetailViewModel model) {
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
                image: model.buildingImage,
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
                    Text(model.building!.name,
                        style: Theme.of(context).textTheme.headline1),
                    _levelText(context, model),
                    Text(model.building!.description),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _levelText(BuildContext context, BuildingDetailViewModel model) {
    if (model.building is LevelableBuilding) {
      return Text('Level ${model.finishedTechnology?.level ?? 0}',
          style: Theme.of(context).textTheme.headline2);
    } else if (model.building is FixedBuilding) {
      return SizedBox.shrink();
    }

    throw Exception(
        'Building ${model.building.runtimeType} is not implemented yet');
  }

  Widget _consumptionWidget(
      BuildContext context, BuildingDetailViewModel model) {
    if (model.technologyValues.length == 0 || model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(
        model, (model.technologyValues.first as BuildingValue).consumptions);

    if (usedResources.length == 0) {
      return SizedBox.shrink();
    }

    double minValue = 0;
    double maxValue = calculateMax(
        (model.technologyValues.last as BuildingValue).consumptions);

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
              'Consumptions',
              style: Theme.of(context).textTheme.headline2,
            ),
          ),
          SizedBox(height: 32),
          Expanded(
            child: LineChart(
              new LineChartData(
                borderData: getBorderData(),
                axisTitleData: getAxisTitleData(context, 'per hour'),
                titlesData: getTitlesData(context, step),
                gridData: getGridData(step),
                lineTouchData: getLineTouchData(context, usedResources),
                lineBarsData: List.generate(
                  usedResources.length,
                  (index) => _generateConsumptionChartData(
                      model, usedResources[index].id, index),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _productionWidget(
      BuildContext context, BuildingDetailViewModel model) {
    if (model.technologyValues.length == 0 || model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(
        model, (model.technologyValues.first as BuildingValue).productions);

    // If there are no resources to produce
    if (usedResources.length == 0) {
      return SizedBox.shrink();
    }

    double minValue = 0;
    double maxValue = calculateMax(
        (model.technologyValues.last as BuildingValue).productions);

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
              'Productions',
              style: Theme.of(context).textTheme.headline2,
            ),
          ),
          SizedBox(height: 32),
          Expanded(
            child: LineChart(
              new LineChartData(
                borderData: getBorderData(),
                axisTitleData: getAxisTitleData(context, 'per hour'),
                titlesData: getTitlesData(context, step),
                gridData: getGridData(step),
                lineTouchData: getLineTouchData(context, usedResources),
                lineBarsData: List.generate(
                  usedResources.length,
                  (index) => _generateProductionChartData(
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
      BuildingDetailViewModel model, List<ResourceAmount> amounts) {
    List<Resource> usedResources = [];

    amounts.forEach((element) {
      usedResources.add(model.resources
          .firstWhere((resource) => resource.id == element.resourceId));
    });

    return usedResources;
  }

  LineChartBarData _generateConsumptionChartData(
      BuildingDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.technologyValues.forEach((element) {
      var costs = (element as BuildingValue)
          .consumptions
          .firstWhere((costs) => costs.resourceId == resourceId);
      var spot =
          new FlSpot(element.level.toDouble(), costs.amount.roundToDouble());
      spots.add(spot);
    });

    return getLineChartBarData(spots, index);
  }

  LineChartBarData _generateProductionChartData(
      BuildingDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.technologyValues.forEach((element) {
      var costs = (element as BuildingValue)
          .productions
          .firstWhere((costs) => costs.resourceId == resourceId);
      var spot =
          new FlSpot(element.level.toDouble(), costs.amount.roundToDouble());
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
              Theme.of(context).textTheme.bodyText1!,
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
        getTextStyles: (value) => Theme.of(context).textTheme.bodyText1!,
        margin: 30,
      ),
      bottomTitles: SideTitles(
        showTitles: true,
        getTextStyles: (value) => Theme.of(context).textTheme.bodyText1!,
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
