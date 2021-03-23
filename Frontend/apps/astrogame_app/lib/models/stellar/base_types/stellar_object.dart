import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class StellarObject extends StellarThing {
  // @JsonKey()
  //SingleObjectSystem parentSystem;

  @JsonKey()
  Guid parentSystemId;

  @JsonKey()
  double averageDistanceToCenter;

  @JsonKey()
  double rotationSpeed;

  @JsonKey()
  int averageTemperature;

  @JsonKey()
  String assetName;

  @JsonKey()
  Coordinates coordinates;

  StellarObject();
}
