import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/converters/stellar_system_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'solar_system.g.dart';

@GuidConverter()
@StellarSystemConverter()
@JsonSerializable()
class SolarSystem extends StellarSystem {
  @JsonKey()
  Guid parentId;

  @JsonKey()
  StellarSystem parent;

  @JsonKey()
  int systemNumber;

  @JsonKey()
  bool isGenerated;

  @JsonKey()
  List<StellarSystem> centerSystems;

  @JsonKey()
  List<StellarSystem> satellites;

  SolarSystem(
    Guid id,
    String name,
    this.parentId,
    //this.parent,
    this.systemNumber,
    this.isGenerated,
    //this.centerSystems,
    //this.satellites,
  ) : super(id, name);

  factory SolarSystem.fromJson(Map<String, dynamic> json) =>
      _$SolarSystemFromJson(json);
  Map<String, dynamic> toJson() => _$SolarSystemToJson(this);
}
