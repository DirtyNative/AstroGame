import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/finished_technologies/finished_technology.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class PlayerDependentFinishedTechnology extends FinishedTechnology {
  @JsonKey()
  late Guid playerId;

  PlayerDependentFinishedTechnology();
}
