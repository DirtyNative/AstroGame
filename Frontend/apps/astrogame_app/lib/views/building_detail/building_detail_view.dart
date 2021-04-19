import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/models/buildings/fixed_building.dart';
import 'package:astrogame_app/models/buildings/levelable_building.dart';
import 'package:astrogame_app/models/buildings/resource_amount.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/building_detail/building_detail_viewmodel.dart';
import 'package:astrogame_app/views/building_detail/widgets/resource_view.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:stacked/stacked.dart';

class BuildingDetailView extends StatelessWidget {
  final Building _building;
  final BuiltBuilding _builtBuilding;

  BuildingDetailView(this._building, this._builtBuilding);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<BuildingDetailViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          margin: EdgeInsets.only(left: 32, right: 32),
          child: ListView(
            children: [
              _headerWidget(context, model),
              (model.building is LevelableBuilding) ? _dynamicBuildingCostsWidget(context, model) : _fixedBuildingCostsWidget(context, model),
              _productionWidget(context, model),
              _consumptionWidget(context, model),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(
        param1: _building,
        param2: _builtBuilding,
      ),
    );
  }

  Widget _headerWidget(BuildContext context, BuildingDetailViewModel model) {
    if (model.buildingImage == null) {
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
                    Text(model.building.name, style: Theme.of(context).textTheme.headline1),
                    _levelText(context, model),
                    Text(model.building.description),
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
      return Text('Level ${model.builtBuilding?.level ?? 0}', style: Theme.of(context).textTheme.headline2);
    } else if (model.building is FixedBuilding) {
      return SizedBox.shrink();
    }

    throw Exception('Building ${model.building.runtimeType} is not implemented yet');
  }

  Widget _fixedBuildingCostsWidget(BuildContext context, BuildingDetailViewModel model) {
    if (model.buildingValues == null || model.buildingValues.length == 0 || model.resources == null || model.resources.length == 0) {
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
                'Building costs',
                style: Theme.of(context).textTheme.headline2,
              ),
            ),
          ),
          SizedBox(height: 16),
          GridView.builder(
            shrinkWrap: true,
            itemCount: model.building.buildingCosts.length,
            itemBuilder: (context, index) {
              var buildingCost = model.building.buildingCosts[index];
              var resource = model.resources.firstWhere((element) => element.id == buildingCost.resourceId);

              return ResourceView(resource, buildingCost);
            },
            gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(maxCrossAxisExtent: 300, childAspectRatio: 3 / 1, crossAxisSpacing: 20, mainAxisSpacing: 20),
          ),
        ],
      ),
    );
  }

  Widget _dynamicBuildingCostsWidget(BuildContext context, BuildingDetailViewModel model) {
    if (model.buildingValues == null || model.buildingValues.length == 0 || model.resources == null || model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(model, model.buildingValues.first.buildingCosts);
    double minValue = 0;
    double maxValue = calculateMax(model.buildingValues.last.buildingCosts);

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
              'Building costs',
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
                  (index) => _generateBuildingCostChartData(model, usedResources[index].id, index),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _consumptionWidget(BuildContext context, BuildingDetailViewModel model) {
    if (model.buildingValues == null || model.buildingValues.length == 0 || model.resources == null || model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(model, model.buildingValues.first.buildingConsumptions);

    if (usedResources == null || usedResources.length == 0) {
      return SizedBox.shrink();
    }

    double minValue = 0;
    double maxValue = calculateMax(model.buildingValues.last.buildingConsumptions);

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
                  (index) => _generateConsumptionChartData(model, usedResources[index].id, index),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _productionWidget(BuildContext context, BuildingDetailViewModel model) {
    if (model.buildingValues == null || model.buildingValues.length == 0 || model.resources == null || model.resources.length == 0) {
      return SizedBox.shrink();
    }

    List<Resource> usedResources = calculateUsedResources(model, model.buildingValues.first.buildingProductions);

    // If there are no resources to produce
    if (usedResources == null || usedResources.length == 0) {
      return SizedBox.shrink();
    }

    double minValue = 0;
    double maxValue = calculateMax(model.buildingValues.last.buildingProductions);

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
                  (index) => _generateProductionChartData(model, usedResources[index].id, index),
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

  List<Resource> calculateUsedResources(BuildingDetailViewModel model, List<ResourceAmount> amounts) {
    List<Resource> usedResources = [];

    amounts.forEach((element) {
      usedResources.add(model.resources.firstWhere((resource) => resource.id == element.resourceId));
    });

    return usedResources;
  }

  LineChartBarData _generateBuildingCostChartData(BuildingDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.buildingValues.forEach((element) {
      var costs = element.buildingCosts.firstWhere((costs) => costs.resourceId == resourceId);
      var spot = new FlSpot(element.level.toDouble(), costs.amount?.roundToDouble() ?? 0);
      spots.add(spot);
    });

    return getLineChartBarData(spots, index);
  }

  LineChartBarData _generateConsumptionChartData(BuildingDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.buildingValues.forEach((element) {
      var costs = element.buildingConsumptions.firstWhere((costs) => costs.resourceId == resourceId);
      var spot = new FlSpot(element.level.toDouble(), costs.amount?.roundToDouble() ?? 0);
      spots.add(spot);
    });

    return getLineChartBarData(spots, index);
  }

  LineChartBarData _generateProductionChartData(BuildingDetailViewModel model, Guid resourceId, int index) {
    List<FlSpot> spots = [];

    model.buildingValues.forEach((element) {
      var costs = element.buildingProductions.firstWhere((costs) => costs.resourceId == resourceId);
      var spot = new FlSpot(element.level.toDouble(), costs.amount?.roundToDouble() ?? 0);
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

  LineTouchData getLineTouchData(BuildContext context, List<Resource> usedResources) {
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
