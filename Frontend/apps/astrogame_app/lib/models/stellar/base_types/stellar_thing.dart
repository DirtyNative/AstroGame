import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class StellarThing {
  @JsonKey()
  late Guid id;

  @JsonKey()
  late String name;
}
