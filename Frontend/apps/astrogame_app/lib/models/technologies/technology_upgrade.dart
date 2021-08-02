import 'package:astrogame_app/communications/converters/technology_upgrade_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

abstract class TechnologyUpgrade {
  late Guid id;
  late Guid technologyId;
  late DateTime startTime;
  late DateTime endTime;
  late String hangfireJobId;

  TechnologyUpgrade();

  factory TechnologyUpgrade.fromJson(Map<String, dynamic> json) =>
      TechnologyUpgradeConverter().fromJson(json);
}
