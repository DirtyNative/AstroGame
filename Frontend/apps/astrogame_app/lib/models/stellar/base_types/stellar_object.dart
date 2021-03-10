import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_thing.dart';
import 'package:astrogame_app/models/stellar/systems/single_object_system.dart';
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

  StellarObject(
    Guid id,
    String name,
    //this.parentSystem,
    this.parentSystemId,
    this.averageDistanceToCenter,
    this.rotationSpeed,
    this.averageTemperature,
    this.assetName,
  ) : super(id, name);
}
