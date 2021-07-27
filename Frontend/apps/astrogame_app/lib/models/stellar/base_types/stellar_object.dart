import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/stellar_object_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class StellarObject extends StellarThing {
  // @JsonKey()
  //SingleObjectSystem parentSystem;

  @JsonKey()
  late Guid parentSystemId;

  @JsonKey()
  double? averageDistanceToCenter;

  @JsonKey()
  late double rotationSpeed;

  @JsonKey()
  late int averageTemperature;

  @JsonKey()
  late String assetName;

  @JsonKey()
  late Coordinates coordinates;

  StellarObject();

  factory StellarObject.fromJson(Map<String, dynamic> json) =>
      StellarObjectConverter().fromJson(json);
}
