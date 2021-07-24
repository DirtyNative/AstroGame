import 'package:flutter_guid/flutter_guid.dart';

abstract class TechnologyUpgrade {
  Guid id;
  Guid technologyId;
  DateTime startTime;
  DateTime endTime;
  String hangfireJobId;
}
