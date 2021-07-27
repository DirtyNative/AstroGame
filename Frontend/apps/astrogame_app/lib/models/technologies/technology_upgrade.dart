import 'package:astrogame_app/models/common/guid.dart';

abstract class TechnologyUpgrade {
  late Guid id;
  late Guid technologyId;
  late DateTime startTime;
  late DateTime endTime;
  late String hangfireJobId;
}
